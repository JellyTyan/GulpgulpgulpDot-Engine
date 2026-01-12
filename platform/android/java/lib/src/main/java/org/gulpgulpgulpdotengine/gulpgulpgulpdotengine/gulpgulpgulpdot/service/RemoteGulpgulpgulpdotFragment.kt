/**************************************************************************/
/*  RemoteGulpgulpgulpdotFragment.kt                                                */
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

package org.gulpgulpgulpdotengine.gulpgulpgulpdot.service

import android.content.ComponentName
import android.content.Context
import android.content.Intent
import android.content.ServiceConnection
import android.os.Build
import android.os.Bundle
import android.os.Handler
import android.os.IBinder
import android.os.Message
import android.os.Messenger
import android.os.RemoteException
import android.util.Log
import android.view.LayoutInflater
import android.view.SurfaceControlViewHost
import android.view.SurfaceView
import android.view.View
import android.view.ViewGroup
import androidx.annotation.RequiresApi
import androidx.fragment.app.Fragment
import org.gulpgulpgulpdotengine.gulpgulpgulpdot.GulpgulpgulpdotHost
import org.gulpgulpgulpdotengine.gulpgulpgulpdot.R
import org.gulpgulpgulpdotengine.gulpgulpgulpdot.service.GulpgulpgulpdotService.EngineStatus.*
import org.gulpgulpgulpdotengine.gulpgulpgulpdot.service.GulpgulpgulpdotService.EngineError.*
import java.lang.ref.WeakReference

/**
 * Gulpgulpgulpdot [Fragment] component showcasing how to drive rendering from another process using a [GulpgulpgulpdotService] instance.
 */
@RequiresApi(Build.VERSION_CODES.R)
class RemoteGulpgulpgulpdotFragment: Fragment() {

	companion object {
		internal val TAG = RemoteGulpgulpgulpdotFragment::class.java.simpleName
	}

	/**
	 * Target we publish for receiving messages from the service.
	 */
	private val messengerForReply = Messenger(IncomingHandler(WeakReference<RemoteGulpgulpgulpdotFragment>(this)))

	/**
	 * Messenger for sending messages to the [GulpgulpgulpdotService] implementation.
	 */
	private var serviceMessenger: Messenger? = null

	private var remoteSurface : SurfaceView? = null

	private var engineInitialized = false
	private var fragmentStarted = false
	private var serviceBound = false
	private var remoteGameArgs = arrayOf<String>()

	private var gulpgulpgulpdotHost : GulpgulpgulpdotHost? = null

	private val serviceConnection = object : ServiceConnection {
		override fun onServiceConnected(name: ComponentName?, service: IBinder?) {
			Log.d(TAG, "Connected to service $name")
			serviceMessenger = Messenger(service)

			// Initialize the GulpGulpGulpDot Engine
			initGulpgulpgulpdotEngine()
		}

		override fun onServiceDisconnected(name: ComponentName?) {
			Log.d(TAG, "Disconnected from service $name")
			serviceMessenger = null
		}
	}

	/**
	 * Handler of incoming messages from [GulpgulpgulpdotService] implementations.
	 */
	private class IncomingHandler(private val fragmentRef: WeakReference<RemoteGulpgulpgulpdotFragment>) : Handler() {

		override fun handleMessage(msg: Message) {
			val fragment = fragmentRef.get() ?: return

			try {
				Log.d(TAG, "HandleMessage: $msg")

				when (msg.what) {
					GulpgulpgulpdotService.MSG_ENGINE_STATUS_UPDATE -> {
						try {
							val engineStatus = GulpgulpgulpdotService.EngineStatus.valueOf(
								msg.data.getString(GulpgulpgulpdotService.KEY_ENGINE_STATUS, "")
							)
							Log.d(TAG, "Received engine status $engineStatus")

							when (engineStatus) {
								INITIALIZED -> {
									Log.d(TAG, "Engine initialized!")

									try {
										Log.i(TAG, "Creating SurfaceControlViewHost...")
										fragment.remoteSurface?.let {
											fragment.serviceMessenger?.send(Message.obtain().apply {
												what = GulpgulpgulpdotService.MSG_WRAP_ENGINE_WITH_SCVH
												data.apply {
													putBinder(GulpgulpgulpdotService.KEY_HOST_TOKEN, it.hostToken)
													putInt(GulpgulpgulpdotService.KEY_DISPLAY_ID, it.display.displayId)
													putInt(GulpgulpgulpdotService.KEY_WIDTH, it.width)
													putInt(GulpgulpgulpdotService.KEY_HEIGHT, it.height)
												}
												replyTo = fragment.messengerForReply
											})
										}
									} catch (e: RemoteException) {
										Log.e(TAG, "Unable to set up SurfaceControlViewHost", e)
									}
								}

								STARTED -> {
									Log.d(TAG, "Engine started!")
								}

								STOPPED -> {
									Log.d(TAG, "Engine stopped!")
								}

								DESTROYED -> {
									Log.d(TAG, "Engine destroyed!")
									fragment.engineInitialized = false
								}

								SCVH_CREATED -> {
									Log.d(TAG, "SurfaceControlViewHost created!")

									val surfacePackage = msg.data.getParcelable<SurfaceControlViewHost.SurfacePackage>(
										GulpgulpgulpdotService.KEY_SURFACE_PACKAGE)
									if (surfacePackage == null) {
										Log.e(TAG, "Unable to retrieve surface package from GulpgulpgulpdotService")
									} else {
										fragment.remoteSurface?.setChildSurfacePackage(surfacePackage)
										fragment.engineInitialized = true
										fragment.startGulpgulpgulpdotEngine()
									}
								}
							}
						} catch (e: IllegalArgumentException) {
							Log.e(TAG, "Unable to retrieve engine status update from $msg")
						}
					}

					GulpgulpgulpdotService.MSG_ENGINE_ERROR -> {
						try {
							val engineError = GulpgulpgulpdotService.EngineError.valueOf(
								msg.data.getString(GulpgulpgulpdotService.KEY_ENGINE_ERROR, "")
							)
							Log.d(TAG, "Received engine error $engineError")

							when (engineError) {
								ALREADY_BOUND -> {
									// Engine is already connected to another client, unbind for now
									fragment.stopRemoteGame(false)
								}

								INIT_FAILED -> {
									Log.e(TAG, "Engine initialization failed")
								}

								SCVH_CREATION_FAILED -> {
									Log.e(TAG, "SurfaceControlViewHost creation failed")
								}
							}
						} catch (e: IllegalArgumentException) {
							Log.e(TAG, "Unable to retrieve engine error from message $msg", e)
						}
					}

					GulpgulpgulpdotService.MSG_ENGINE_RESTART_REQUESTED -> {
						Log.d(TAG, "Engine restart requested")
						// Validate the engine is actually running
						if (!fragment.serviceBound || !fragment.engineInitialized) {
							return
						}

						// Retrieve the current game args since stopping the engine will clear them out
						val currentArgs = fragment.remoteGameArgs

						// Stop the engine
						fragment.stopRemoteGame()

						// Restart the engine
						fragment.startRemoteGame(currentArgs)
					}

					else -> super.handleMessage(msg)
				}
			} catch (e: RemoteException) {
				Log.e(TAG, "Unable to handle message $msg", e)
			}
		}
	}

	override fun onAttach(context: Context) {
		super.onAttach(context)
		val parentActivity = activity
		if (parentActivity is GulpgulpgulpdotHost) {
			gulpgulpgulpdotHost = parentActivity
		} else {
			val parentFragment = parentFragment
			if (parentFragment is GulpgulpgulpdotHost) {
				gulpgulpgulpdotHost = parentFragment
			}
		}
	}

	override fun onDetach() {
		super.onDetach()
		gulpgulpgulpdotHost = null
	}

	override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, bundle: Bundle?): View? {
		return inflater.inflate(R.layout.remote_gulpgulpgulpdot_fragment_layout, container, false)
	}

	override fun onViewCreated(view: View, bundle: Bundle?) {
		super.onViewCreated(view, bundle)
		remoteSurface = view.findViewById(R.id.remote_gulpgulpgulpdot_window_surface)
		remoteSurface?.setZOrderOnTop(false)

		initGulpgulpgulpdotEngine()
	}

	fun startRemoteGame(args: Array<String>) {
		Log.d(TAG, "Starting remote game with args: ${args.contentToString()}")
		remoteSurface?.setZOrderOnTop(true)
		remoteGameArgs = args
		context?.bindService(
			Intent(context, GulpgulpgulpdotService::class.java),
			serviceConnection,
			Context.BIND_AUTO_CREATE
		)
		serviceBound = true
	}

	fun stopRemoteGame(destroyEngine: Boolean = true) {
		Log.d(TAG, "Stopping remote game")
		remoteSurface?.setZOrderOnTop(false)
		remoteGameArgs = arrayOf()

		if (serviceBound) {
			if (destroyEngine) {
				serviceMessenger?.send(Message.obtain().apply {
					what = GulpgulpgulpdotService.MSG_DESTROY_ENGINE
					replyTo = messengerForReply
				})
			}
			context?.unbindService(serviceConnection)
			serviceBound = false
		}
	}

	private fun initGulpgulpgulpdotEngine() {
		if (!serviceBound) {
			return
		}

		try {
			serviceMessenger?.send(Message.obtain().apply {
				what = GulpgulpgulpdotService.MSG_INIT_ENGINE
				data.apply {
					putStringArray(GulpgulpgulpdotService.KEY_COMMAND_LINE_PARAMETERS, remoteGameArgs)
				}
				replyTo = messengerForReply
			})
		} catch (e: RemoteException) {
			Log.e(TAG, "Unable to initialize GulpGulpGulpDot Engine", e)
		}
	}

	private fun startGulpgulpgulpdotEngine() {
		if (!serviceBound || !engineInitialized || !fragmentStarted) {
			return
		}
		try {
			serviceMessenger?.send(Message.obtain().apply {
				what = GulpgulpgulpdotService.MSG_START_ENGINE
				replyTo = messengerForReply
			})
		} catch (e: RemoteException) {
			Log.e(TAG, "Unable to start GulpGulpGulpDot Engine", e)
		}
	}

	private fun stopGulpgulpgulpdotEngine() {
		if (!serviceBound || !engineInitialized || fragmentStarted) {
			return
		}
		try {
			serviceMessenger?.send(Message.obtain().apply {
				what = GulpgulpgulpdotService.MSG_STOP_ENGINE
				replyTo = messengerForReply
			})
		} catch (e: RemoteException) {
			Log.e(TAG, "Unable to stop GulpGulpGulpDot Engine", e)
		}
	}

	override fun onStart() {
		super.onStart()
		fragmentStarted = true
		startGulpgulpgulpdotEngine()
	}

	override fun onStop() {
		super.onStop()
		fragmentStarted = false
		stopGulpgulpgulpdotEngine()
	}

	override fun onDestroy() {
		stopRemoteGame()
		super.onDestroy()
	}
}
