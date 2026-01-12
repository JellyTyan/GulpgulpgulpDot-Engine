/**************************************************************************/
/*  GradleBuildProvider.kt                                                */
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

package org.gulpgulpgulpdotengine.editor.buildprovider

import android.content.Context
import org.gulpgulpgulpdotengine.gulpgulpgulpdot.BuildProvider
import org.gulpgulpgulpdotengine.gulpgulpgulpdot.GulpgulpgulpdotHost
import org.gulpgulpgulpdotengine.gulpgulpgulpdot.variant.Callable

internal class GradleBuildProvider(
	val context: Context,
	val host: GulpgulpgulpdotHost,
) : BuildProvider {

	val gradleBuildEnvironmentClient = GradleBuildEnvironmentClient(context)

	val gulpgulpgulpdot get() = host.gulpgulpgulpdot

	override fun buildEnvConnect(callback: Callable): Boolean {
		return gradleBuildEnvironmentClient.connect {
			gulpgulpgulpdot?.runOnRenderThread {
				callback.call()
			}
		}
	}

	override fun buildEnvDisconnect() {
		gradleBuildEnvironmentClient.disconnect()
	}

	override fun buildEnvExecute(
		buildTool: String,
		arguments: Array<String>,
		projectPath: String,
		buildDir: String,
		outputCallback: Callable,
		resultCallback: Callable
	): Int {
		if (buildTool != "gradle") {
			return -1;
		}
		val outputCb: (Int, String) -> Unit = { outputType, line ->
			gulpgulpgulpdot?.runOnRenderThread {
				outputCallback.call(outputType, line)
			}
		}
		val resultCb: (Int) -> Unit = { exitCode ->
			gulpgulpgulpdot?.runOnRenderThread {
				resultCallback.call(exitCode)
			}
		}
		return gradleBuildEnvironmentClient.execute(arguments, projectPath, buildDir, outputCb, resultCb)
	}

	override fun buildEnvCancel(jobId: Int) {
		gradleBuildEnvironmentClient.cancel(jobId)
	}

	override fun buildEnvCleanProject(projectPath: String, buildDir: String, callback: Callable) {
		val cb: (Int) -> Unit = { exitCode ->
			gulpgulpgulpdot?.runOnRenderThread {
				callback.call()
			}
		}
		gradleBuildEnvironmentClient.cleanProject(projectPath, buildDir, cb)
	}
}
