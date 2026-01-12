/**************************************************************************/
/*  GulpgulpgulpdotApp.java                                                         */
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

package com.gulpgulpgulpdot.game;

import org.gulpgulpgulpdotengine.gulpgulpgulpdot.Gulpgulpgulpdot;
import org.gulpgulpgulpdotengine.gulpgulpgulpdot.GulpgulpgulpdotActivity;

import android.os.Bundle;
import android.util.Log;

import androidx.activity.EdgeToEdge;
import androidx.core.splashscreen.SplashScreen;

/**
 * Template activity for Gulpgulpgulpdot Android builds.
 * Feel free to extend and modify this class for your custom logic.
 */
public class GulpgulpgulpdotApp extends GulpgulpgulpdotActivity {
	static {
		// .NET libraries.
		if (BuildConfig.FLAVOR.equals("mono")) {
			try {
				Log.v("GULPGULPGULPDOT", "Loading System.Security.Cryptography.Native.Android library");
				System.loadLibrary("System.Security.Cryptography.Native.Android");
			} catch (UnsatisfiedLinkError e) {
				Log.e("GULPGULPGULPDOT", "Unable to load System.Security.Cryptography.Native.Android library");
			}
		}
	}

	private final Runnable updateWindowAppearance = () -> {
		Gulpgulpgulpdot gulpgulpgulpdot = getGulpgulpgulpdot();
		if (gulpgulpgulpdot != null) {
			gulpgulpgulpdot.enableImmersiveMode(gulpgulpgulpdot.isInImmersiveMode(), true);
			gulpgulpgulpdot.enableEdgeToEdge(gulpgulpgulpdot.isInEdgeToEdgeMode(), true);
			gulpgulpgulpdot.setSystemBarsAppearance();
		}
	};

	@Override
	public void onCreate(Bundle savedInstanceState) {
		SplashScreen.installSplashScreen(this);
		EdgeToEdge.enable(this);
		super.onCreate(savedInstanceState);
	}

	@Override
	public void onResume() {
		super.onResume();
		updateWindowAppearance.run();
	}

	@Override
	public void onGulpgulpgulpdotMainLoopStarted() {
		super.onGulpgulpgulpdotMainLoopStarted();
		runOnUiThread(updateWindowAppearance);
	}

	@Override
	public void onGulpgulpgulpdotForceQuit(Gulpgulpgulpdot instance) {
		if (!BuildConfig.FLAVOR.equals("instrumented")) {
			// For instrumented builds, we disable force-quitting to allow the instrumented tests to complete
			// successfully, otherwise they fail when the process crashes.
			super.onGulpgulpgulpdotForceQuit(instance);
		}
	}
}
