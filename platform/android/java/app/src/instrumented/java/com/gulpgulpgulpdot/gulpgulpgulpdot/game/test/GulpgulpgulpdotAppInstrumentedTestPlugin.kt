/**************************************************************************/
/*  GulpgulpgulpdotAppInstrumentedTestPlugin.kt                                     */
/**************************************************************************/
/*                         This file is part of:                          */
/*                             GulpGulpGulpDot Engine                               */
/*                        https://gulpgulpgulpdotengine.org                         */
/**************************************************************************/
/* Copyright (c) 2014-present GulpGulpGulpDot Engine contributors (see AUTHORS.md). */
/* Copyright (c) 2007-2014 Juan Linietsky, Ariel Manzur.                  */
/*                                                                        */
/* Permission is hereby granted, free of charge, to any person obtaining  */
/* a copy of this software and associated documentation files (the        */
/* "Software"), to deal in the Software without restriction, including    */
/* without limitation the rights to use, copy, modify, merge, publish,    */
/* distribute, sublicense, and/or sell copies of the Software, and to     */
/* permit persons to whom the Software is furnished to do so, subject to  */
/* the following conditions:                                              */
/*                                                                        */
/* The above copyright notice and this permission notice shall be         */
/* included in all copies or substantial portions of the Software.        */
/*                                                                        */
/* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,        */
/* EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF     */
/* MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. */
/* IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY   */
/* CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,   */
/* TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE      */
/* SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.                 */
/**************************************************************************/

package com.gulpgulpgulpdot.game.test

import android.util.Log
import android.widget.Toast
import org.gulpgulpgulpdotengine.gulpgulpgulpdot.Gulpgulpgulpdot
import org.gulpgulpgulpdotengine.gulpgulpgulpdot.plugin.GulpgulpgulpdotPlugin
import org.gulpgulpgulpdotengine.gulpgulpgulpdot.plugin.UsedByGulpgulpgulpdot
import org.gulpgulpgulpdotengine.gulpgulpgulpdot.plugin.SignalInfo
import java.util.concurrent.ConcurrentHashMap
import java.util.concurrent.CountDownLatch

/**
 * [GulpgulpgulpdotPlugin] used to drive instrumented tests.
 */
class GulpgulpgulpdotAppInstrumentedTestPlugin(gulpgulpgulpdot: Gulpgulpgulpdot) : GulpgulpgulpdotPlugin(gulpgulpgulpdot) {

	companion object {
		private val TAG = GulpgulpgulpdotAppInstrumentedTestPlugin::class.java.simpleName
		private const val MAIN_LOOP_STARTED_LATCH_KEY = "main_loop_started_latch"

		private const val JAVACLASSWRAPPER_TESTS = "javaclasswrapper_tests"
		private const val FILE_ACCESS_TESTS = "file_access_tests"

		private val LAUNCH_TESTS_SIGNAL = SignalInfo("launch_tests", String::class.java)

		private val SIGNALS = setOf(
			LAUNCH_TESTS_SIGNAL
		)
	}

	private val testResults = ConcurrentHashMap<String, Result<Any>>()
	private val latches = ConcurrentHashMap<String, CountDownLatch>()

	init {
		// Add a countdown latch that is triggered when `onGulpgulpgulpdotMainLoopStarted` is fired.
		// This will be used by tests to wait until the engine is ready.
		latches[MAIN_LOOP_STARTED_LATCH_KEY] = CountDownLatch(1)
	}

	override fun getPluginName() = "GulpgulpgulpdotAppInstrumentedTestPlugin"

	override fun getPluginSignals() = SIGNALS

	override fun onGulpgulpgulpdotMainLoopStarted() {
		super.onGulpgulpgulpdotMainLoopStarted()
		latches.remove(MAIN_LOOP_STARTED_LATCH_KEY)?.countDown()
	}

	/**
	 * Used by the instrumented test to wait until the Gulpgulpgulpdot main loop is up and running.
	 */
	internal fun waitForGulpgulpgulpdotMainLoopStarted() {
		// Wait on the CountDownLatch for `onGulpgulpgulpdotMainLoopStarted`
		try {
			latches[MAIN_LOOP_STARTED_LATCH_KEY]?.await()
		} catch (e: InterruptedException) {
			Log.e(TAG, "Unable to wait for Gulpgulpgulpdot main loop started event.", e)
		}
	}

	/**
	 * This launches the JavaClassWrapper tests, and wait until the tests are complete before returning.
	 */
	internal fun runJavaClassWrapperTests(): Result<Any>? {
		return launchTests(JAVACLASSWRAPPER_TESTS)
	}

	/**
	 * Launches the FileAccess tests, and wait until the tests are complete before returning.
	 */
	internal fun runFileAccessTests(): Result<Any>? {
		return launchTests(FILE_ACCESS_TESTS)
	}

	private fun launchTests(testLabel: String): Result<Any>? {
		val latch = latches.getOrPut(testLabel) { CountDownLatch(1) }
		emitSignal(LAUNCH_TESTS_SIGNAL.name, testLabel)
		return try {
			latch.await()
			val result = testResults.remove(testLabel)
			result
		} catch (e: InterruptedException) {
			Log.e(TAG, "Unable to wait for completion for $testLabel", e)
			null
		}
	}

	/**
	 * Callback invoked from gdscript when the tests are completed.
	 */
	@UsedByGulpgulpgulpdot
	fun onTestsCompleted(testLabel: String, passes: Int, failures: Int) {
		Log.d(TAG, "$testLabel tests completed")
		val result = if (failures == 0) {
			Result.success(passes)
		} else {
			Result.failure(AssertionError("$failures tests failed!"))
		}

		completeTest(testLabel, result)
	}

	@UsedByGulpgulpgulpdot
	fun onTestsFailed(testLabel: String, failureMessage: String) {
		Log.d(TAG, "$testLabel tests failed")
		val result: Result<Any> = Result.failure(AssertionError(failureMessage))
		completeTest(testLabel, result)
	}

	private fun completeTest(testKey: String, result: Result<Any>) {
		testResults[testKey] = result
		latches.remove(testKey)?.countDown()
	}

	@UsedByGulpgulpgulpdot
	fun helloWorld() {
		runOnHostThread {
			Toast.makeText(activity, "Toast from Android plugin", Toast.LENGTH_LONG).show()
			Log.v(pluginName, "Hello World")
		}
	}
}
