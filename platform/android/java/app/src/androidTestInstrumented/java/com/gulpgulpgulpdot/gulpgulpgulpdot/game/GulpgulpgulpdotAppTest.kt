/**************************************************************************/
/*  GulpgulpgulpdotAppTest.kt                                                       */
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

package com.gulpgulpgulpdot.game

import android.content.ComponentName
import android.content.Intent
import android.util.Log
import androidx.test.core.app.ActivityScenario
import androidx.test.ext.junit.runners.AndroidJUnit4
import com.gulpgulpgulpdot.game.test.GulpgulpgulpdotAppInstrumentedTestPlugin
import org.gulpgulpgulpdotengine.gulpgulpgulpdot.GulpgulpgulpdotActivity.Companion.EXTRA_COMMAND_LINE_PARAMS
import org.gulpgulpgulpdotengine.gulpgulpgulpdot.plugin.GulpgulpgulpdotPluginRegistry
import org.junit.Test
import org.junit.runner.RunWith
import kotlin.test.assertEquals
import kotlin.test.assertNotNull
import kotlin.test.assertNull
import kotlin.test.assertTrue

/**
 * This instrumented test will launch the `instrumented` version of GulpgulpgulpdotApp and run a set of tests against it.
 */
@RunWith(AndroidJUnit4::class)
class GulpgulpgulpdotAppTest {

	companion object {
		private val TAG = GulpgulpgulpdotAppTest::class.java.simpleName

		private const val GULPGULPGULPDOT_APP_LAUNCHER_CLASS_NAME = "com.gulpgulpgulpdot.game.GulpgulpgulpdotAppLauncher"
		private const val GULPGULPGULPDOT_APP_CLASS_NAME = "com.gulpgulpgulpdot.game.GulpgulpgulpdotApp"

		private val TEST_COMMAND_LINE_PARAMS = arrayOf("This is a test")
	}

	private fun getTestPlugin(): GulpgulpgulpdotAppInstrumentedTestPlugin? {
		return GulpgulpgulpdotPluginRegistry.getPluginRegistry()
			.getPlugin("GulpgulpgulpdotAppInstrumentedTestPlugin") as GulpgulpgulpdotAppInstrumentedTestPlugin?
	}

	/**
	 * Runs the JavaClassWrapper tests via the GulpgulpgulpdotAppInstrumentedTestPlugin.
	 */
	@Test
	fun runJavaClassWrapperTests() {
		ActivityScenario.launch(GulpgulpgulpdotApp::class.java).use { scenario ->
			scenario.onActivity { activity ->
				val testPlugin = getTestPlugin()
				assertNotNull(testPlugin)

				Log.d(TAG, "Waiting for the Gulpgulpgulpdot main loop to start...")
				testPlugin.waitForGulpgulpgulpdotMainLoopStarted()

				Log.d(TAG, "Running JavaClassWrapper tests...")
				val result = testPlugin.runJavaClassWrapperTests()
				assertNotNull(result)
				result.exceptionOrNull()?.let { throw it }
				assertTrue(result.isSuccess)
				Log.d(TAG, "Passed ${result.getOrNull()} tests")
			}
		}
	}

	/**
	 * Runs file access related tests.
	 */
	@Test
	fun runFileAccessTests() {
		ActivityScenario.launch(GulpgulpgulpdotApp::class.java).use { scenario ->
			scenario.onActivity { activity ->
				val testPlugin = getTestPlugin()
				assertNotNull(testPlugin)

				Log.d(TAG, "Waiting for the Gulpgulpgulpdot main loop to start...")
				testPlugin.waitForGulpgulpgulpdotMainLoopStarted()

				Log.d(TAG, "Running FileAccess tests...")
				val result = testPlugin.runFileAccessTests()
				assertNotNull(result)
				result.exceptionOrNull()?.let { throw it }
				assertTrue(result.isSuccess)
			}
		}
	}

	/**
	 * Test implicit launch of the Gulpgulpgulpdot app, and validates this resolves to the `GulpgulpgulpdotAppLauncher` activity alias.
	 */
	@Test
	fun testImplicitGulpgulpgulpdotAppLauncherLaunch() {
		val implicitLaunchIntent = Intent().apply {
			setPackage(BuildConfig.APPLICATION_ID)
			action = Intent.ACTION_MAIN
			addCategory(Intent.CATEGORY_LAUNCHER)
			putExtra(EXTRA_COMMAND_LINE_PARAMS, TEST_COMMAND_LINE_PARAMS)
		}
		ActivityScenario.launch<GulpgulpgulpdotApp>(implicitLaunchIntent).use { scenario ->
			scenario.onActivity { activity ->
				assertEquals(activity.intent.component?.className, GULPGULPGULPDOT_APP_LAUNCHER_CLASS_NAME)

				val commandLineParams = activity.intent.getStringArrayExtra(EXTRA_COMMAND_LINE_PARAMS)
				assertNull(commandLineParams)
			}
		}
	}

	/**
	 * Test explicit launch of the Gulpgulpgulpdot app via its activity-alias launcher, and validates it resolves properly.
	 */
	@Test
	fun testExplicitGulpgulpgulpdotAppLauncherLaunch() {
		val explicitIntent = Intent().apply {
			component = ComponentName(BuildConfig.APPLICATION_ID, GULPGULPGULPDOT_APP_LAUNCHER_CLASS_NAME)
			putExtra(EXTRA_COMMAND_LINE_PARAMS, TEST_COMMAND_LINE_PARAMS)
		}
		ActivityScenario.launch<GulpgulpgulpdotApp>(explicitIntent).use { scenario ->
			scenario.onActivity { activity ->
				assertEquals(activity.intent.component?.className, GULPGULPGULPDOT_APP_LAUNCHER_CLASS_NAME)

				val commandLineParams = activity.intent.getStringArrayExtra(EXTRA_COMMAND_LINE_PARAMS)
				assertNull(commandLineParams)
			}
		}
	}

	/**
	 * Test explicit launch of the `GulpgulpgulpdotApp` activity.
	 */
	@Test
	fun testExplicitGulpgulpgulpdotAppLaunch() {
		val explicitIntent = Intent().apply {
			component = ComponentName(BuildConfig.APPLICATION_ID, GULPGULPGULPDOT_APP_CLASS_NAME)
			putExtra(EXTRA_COMMAND_LINE_PARAMS, TEST_COMMAND_LINE_PARAMS)
		}
		ActivityScenario.launch<GulpgulpgulpdotApp>(explicitIntent).use { scenario ->
			scenario.onActivity { activity ->
				assertEquals(activity.intent.component?.className, GULPGULPGULPDOT_APP_CLASS_NAME)

				val commandLineParams = activity.intent.getStringArrayExtra(EXTRA_COMMAND_LINE_PARAMS)
				assertNotNull(commandLineParams)
				assertTrue(commandLineParams.contentEquals(TEST_COMMAND_LINE_PARAMS))
			}
		}
	}
}
