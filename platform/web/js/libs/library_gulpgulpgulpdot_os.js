/**************************************************************************/
/*  library_gulpgulpgulpdot_os.js                                                   */
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

const IDHandler = {
	$IDHandler: {
		_last_id: 0,
		_references: {},

		get: function (p_id) {
			return IDHandler._references[p_id];
		},

		add: function (p_data) {
			const id = ++IDHandler._last_id;
			IDHandler._references[id] = p_data;
			return id;
		},

		remove: function (p_id) {
			delete IDHandler._references[p_id];
		},
	},
};

autoAddDeps(IDHandler, '$IDHandler');
mergeInto(LibraryManager.library, IDHandler);

const GulpgulpgulpdotConfig = {
	$GulpgulpgulpdotConfig__postset: 'Module["initConfig"] = GulpgulpgulpdotConfig.init_config;',
	$GulpgulpgulpdotConfig__deps: ['$GulpgulpgulpdotRuntime'],
	$GulpgulpgulpdotConfig: {
		canvas: null,
		locale: 'en',
		canvas_resize_policy: 2, // Adaptive
		virtual_keyboard: false,
		persistent_drops: false,
		gulpgulpgulpdot_pool_size: 4,
		on_execute: null,
		on_exit: null,

		init_config: function (p_opts) {
			GulpgulpgulpdotConfig.canvas_resize_policy = p_opts['canvasResizePolicy'];
			GulpgulpgulpdotConfig.canvas = p_opts['canvas'];
			GulpgulpgulpdotConfig.locale = p_opts['locale'] || GulpgulpgulpdotConfig.locale;
			GulpgulpgulpdotConfig.virtual_keyboard = p_opts['virtualKeyboard'];
			GulpgulpgulpdotConfig.persistent_drops = !!p_opts['persistentDrops'];
			GulpgulpgulpdotConfig.gulpgulpgulpdot_pool_size = p_opts['gulpgulpgulpdotPoolSize'];
			GulpgulpgulpdotConfig.on_execute = p_opts['onExecute'];
			GulpgulpgulpdotConfig.on_exit = p_opts['onExit'];
			if (p_opts['focusCanvas']) {
				GulpgulpgulpdotConfig.canvas.focus();
			}
		},

		locate_file: function (file) {
			return Module['locateFile'](file);
		},
		clear: function () {
			GulpgulpgulpdotConfig.canvas = null;
			GulpgulpgulpdotConfig.locale = 'en';
			GulpgulpgulpdotConfig.canvas_resize_policy = 2;
			GulpgulpgulpdotConfig.virtual_keyboard = false;
			GulpgulpgulpdotConfig.persistent_drops = false;
			GulpgulpgulpdotConfig.on_execute = null;
			GulpgulpgulpdotConfig.on_exit = null;
		},
	},

	gulpgulpgulpdot_js_config_canvas_id_get__proxy: 'sync',
	gulpgulpgulpdot_js_config_canvas_id_get__sig: 'vii',
	gulpgulpgulpdot_js_config_canvas_id_get: function (p_ptr, p_ptr_max) {
		GulpgulpgulpdotRuntime.stringToHeap(`#${GulpgulpgulpdotConfig.canvas.id}`, p_ptr, p_ptr_max);
	},

	gulpgulpgulpdot_js_config_locale_get__proxy: 'sync',
	gulpgulpgulpdot_js_config_locale_get__sig: 'vii',
	gulpgulpgulpdot_js_config_locale_get: function (p_ptr, p_ptr_max) {
		GulpgulpgulpdotRuntime.stringToHeap(GulpgulpgulpdotConfig.locale, p_ptr, p_ptr_max);
	},
};

autoAddDeps(GulpgulpgulpdotConfig, '$GulpgulpgulpdotConfig');
mergeInto(LibraryManager.library, GulpgulpgulpdotConfig);

const GulpgulpgulpdotFS = {
	$GulpgulpgulpdotFS__deps: ['$FS', '$IDBFS', '$GulpgulpgulpdotRuntime'],
	$GulpgulpgulpdotFS__postset: [
		'Module["initFS"] = GulpgulpgulpdotFS.init;',
		'Module["copyToFS"] = GulpgulpgulpdotFS.copy_to_fs;',
	].join(''),
	$GulpgulpgulpdotFS: {
		// ERRNO_CODES works every odd version of emscripten, but this will break too eventually.
		ENOENT: 44,
		_idbfs: false,
		_syncing: false,
		_mount_points: [],

		is_persistent: function () {
			return GulpgulpgulpdotFS._idbfs ? 1 : 0;
		},

		// Initialize gulpgulpgulpdot file system, setting up persistent paths.
		// Returns a promise that resolves when the FS is ready.
		// We keep track of mount_points, so that we can properly close the IDBFS
		// since emscripten is not doing it by itself. (emscripten GH#12516).
		init: function (persistentPaths) {
			GulpgulpgulpdotFS._idbfs = false;
			if (!Array.isArray(persistentPaths)) {
				return Promise.reject(new Error('Persistent paths must be an array'));
			}
			if (!persistentPaths.length) {
				return Promise.resolve();
			}
			GulpgulpgulpdotFS._mount_points = persistentPaths.slice();

			function createRecursive(dir) {
				try {
					FS.stat(dir);
				} catch (e) {
					if (e.errno !== GulpgulpgulpdotFS.ENOENT) {
						// Let mkdirTree throw in case, we cannot trust the above check.
						GulpgulpgulpdotRuntime.error(e);
					}
					FS.mkdirTree(dir);
				}
			}

			GulpgulpgulpdotFS._mount_points.forEach(function (path) {
				createRecursive(path);
				FS.mount(IDBFS, {}, path);
			});
			return new Promise(function (resolve, reject) {
				FS.syncfs(true, function (err) {
					if (err) {
						GulpgulpgulpdotFS._mount_points = [];
						GulpgulpgulpdotFS._idbfs = false;
						GulpgulpgulpdotRuntime.print(`IndexedDB not available: ${err.message}`);
					} else {
						GulpgulpgulpdotFS._idbfs = true;
					}
					resolve(err);
				});
			});
		},

		// Deinit gulpgulpgulpdot file system, making sure to unmount file systems, and close IDBFS(s).
		deinit: function () {
			GulpgulpgulpdotFS._mount_points.forEach(function (path) {
				try {
					FS.unmount(path);
				} catch (e) {
					GulpgulpgulpdotRuntime.print('Already unmounted', e);
				}
				if (GulpgulpgulpdotFS._idbfs && IDBFS.dbs[path]) {
					IDBFS.dbs[path].close();
					delete IDBFS.dbs[path];
				}
			});
			GulpgulpgulpdotFS._mount_points = [];
			GulpgulpgulpdotFS._idbfs = false;
			GulpgulpgulpdotFS._syncing = false;
		},

		sync: function () {
			if (GulpgulpgulpdotFS._syncing) {
				GulpgulpgulpdotRuntime.error('Already syncing!');
				return Promise.resolve();
			}
			GulpgulpgulpdotFS._syncing = true;
			return new Promise(function (resolve, reject) {
				FS.syncfs(false, function (error) {
					if (error) {
						GulpgulpgulpdotRuntime.error(`Failed to save IDB file system: ${error.message}`);
					}
					GulpgulpgulpdotFS._syncing = false;
					resolve(error);
				});
			});
		},

		// Copies a buffer to the internal file system. Creating directories recursively.
		copy_to_fs: function (path, buffer) {
			const idx = path.lastIndexOf('/');
			let dir = '/';
			if (idx > 0) {
				dir = path.slice(0, idx);
			}
			try {
				FS.stat(dir);
			} catch (e) {
				if (e.errno !== GulpgulpgulpdotFS.ENOENT) {
					// Let mkdirTree throw in case, we cannot trust the above check.
					GulpgulpgulpdotRuntime.error(e);
				}
				FS.mkdirTree(dir);
			}
			FS.writeFile(path, new Uint8Array(buffer));
		},
	},
};
mergeInto(LibraryManager.library, GulpgulpgulpdotFS);

const GulpgulpgulpdotOS = {
	$GulpgulpgulpdotOS__deps: ['$GulpgulpgulpdotRuntime', '$GulpgulpgulpdotConfig', '$GulpgulpgulpdotFS'],
	$GulpgulpgulpdotOS__postset: [
		'Module["request_quit"] = function() { GulpgulpgulpdotOS.request_quit() };',
		'Module["onExit"] = GulpgulpgulpdotOS.cleanup;',
		'GulpgulpgulpdotOS._fs_sync_promise = Promise.resolve();',
	].join(''),
	$GulpgulpgulpdotOS: {
		request_quit: function () {},
		_async_cbs: [],
		_fs_sync_promise: null,

		atexit: function (p_promise_cb) {
			GulpgulpgulpdotOS._async_cbs.push(p_promise_cb);
		},

		cleanup: function (exit_code) {
			const cb = GulpgulpgulpdotConfig.on_exit;
			GulpgulpgulpdotFS.deinit();
			GulpgulpgulpdotConfig.clear();
			if (cb) {
				cb(exit_code);
			}
		},

		finish_async: function (callback) {
			GulpgulpgulpdotOS._fs_sync_promise.then(function (err) {
				const promises = [];
				GulpgulpgulpdotOS._async_cbs.forEach(function (cb) {
					promises.push(new Promise(cb));
				});
				return Promise.all(promises);
			}).then(function () {
				return GulpgulpgulpdotFS.sync(); // Final FS sync.
			}).then(function (err) {
				// Always deferred.
				setTimeout(function () {
					callback();
				}, 0);
			});
		},
	},

	gulpgulpgulpdot_js_os_finish_async__proxy: 'sync',
	gulpgulpgulpdot_js_os_finish_async__sig: 'vi',
	gulpgulpgulpdot_js_os_finish_async: function (p_callback) {
		const func = GulpgulpgulpdotRuntime.get_func(p_callback);
		GulpgulpgulpdotOS.finish_async(func);
	},

	gulpgulpgulpdot_js_os_request_quit_cb__proxy: 'sync',
	gulpgulpgulpdot_js_os_request_quit_cb__sig: 'vi',
	gulpgulpgulpdot_js_os_request_quit_cb: function (p_callback) {
		GulpgulpgulpdotOS.request_quit = GulpgulpgulpdotRuntime.get_func(p_callback);
	},

	gulpgulpgulpdot_js_os_fs_is_persistent__proxy: 'sync',
	gulpgulpgulpdot_js_os_fs_is_persistent__sig: 'i',
	gulpgulpgulpdot_js_os_fs_is_persistent: function () {
		return GulpgulpgulpdotFS.is_persistent();
	},

	gulpgulpgulpdot_js_os_fs_sync__proxy: 'sync',
	gulpgulpgulpdot_js_os_fs_sync__sig: 'vi',
	gulpgulpgulpdot_js_os_fs_sync: function (callback) {
		const func = GulpgulpgulpdotRuntime.get_func(callback);
		GulpgulpgulpdotOS._fs_sync_promise = GulpgulpgulpdotFS.sync();
		GulpgulpgulpdotOS._fs_sync_promise.then(function (err) {
			func();
		});
	},

	gulpgulpgulpdot_js_os_has_feature__proxy: 'sync',
	gulpgulpgulpdot_js_os_has_feature__sig: 'ii',
	gulpgulpgulpdot_js_os_has_feature: function (p_ftr) {
		const ftr = GulpgulpgulpdotRuntime.parseString(p_ftr);
		const ua = navigator.userAgent;
		if (ftr === 'web_macos') {
			return (ua.indexOf('Mac') !== -1) ? 1 : 0;
		}
		if (ftr === 'web_windows') {
			return (ua.indexOf('Windows') !== -1) ? 1 : 0;
		}
		if (ftr === 'web_android') {
			return (ua.indexOf('Android') !== -1) ? 1 : 0;
		}
		if (ftr === 'web_ios') {
			return ((ua.indexOf('iPhone') !== -1) || (ua.indexOf('iPad') !== -1) || (ua.indexOf('iPod') !== -1)) ? 1 : 0;
		}
		if (ftr === 'web_linuxbsd') {
			return ((ua.indexOf('CrOS') !== -1) || (ua.indexOf('BSD') !== -1) || (ua.indexOf('Linux') !== -1) || (ua.indexOf('X11') !== -1)) ? 1 : 0;
		}
		return 0;
	},

	gulpgulpgulpdot_js_os_execute__proxy: 'sync',
	gulpgulpgulpdot_js_os_execute__sig: 'ii',
	gulpgulpgulpdot_js_os_execute: function (p_json) {
		const json_args = GulpgulpgulpdotRuntime.parseString(p_json);
		const args = JSON.parse(json_args);
		if (GulpgulpgulpdotConfig.on_execute) {
			GulpgulpgulpdotConfig.on_execute(args);
			return 0;
		}
		return 1;
	},

	gulpgulpgulpdot_js_os_shell_open__proxy: 'sync',
	gulpgulpgulpdot_js_os_shell_open__sig: 'vi',
	gulpgulpgulpdot_js_os_shell_open: function (p_uri) {
		window.open(GulpgulpgulpdotRuntime.parseString(p_uri), '_blank');
	},

	gulpgulpgulpdot_js_os_hw_concurrency_get__proxy: 'sync',
	gulpgulpgulpdot_js_os_hw_concurrency_get__sig: 'i',
	gulpgulpgulpdot_js_os_hw_concurrency_get: function () {
		// TODO Gulpgulpgulpdot core needs fixing to avoid spawning too many threads (> 24).
		const concurrency = navigator.hardwareConcurrency || 1;
		return concurrency < 2 ? concurrency : 2;
	},

	gulpgulpgulpdot_js_os_thread_pool_size_get__proxy: 'sync',
	gulpgulpgulpdot_js_os_thread_pool_size_get__sig: 'i',
	gulpgulpgulpdot_js_os_thread_pool_size_get: function () {
		if (typeof PThread === 'undefined') {
			// Threads aren't supported, so default to `1`.
			return 1;
		}

		return GulpgulpgulpdotConfig.gulpgulpgulpdot_pool_size;
	},

	gulpgulpgulpdot_js_os_download_buffer__proxy: 'sync',
	gulpgulpgulpdot_js_os_download_buffer__sig: 'viiii',
	gulpgulpgulpdot_js_os_download_buffer: function (p_ptr, p_size, p_name, p_mime) {
		const buf = GulpgulpgulpdotRuntime.heapSlice(HEAP8, p_ptr, p_size);
		const name = GulpgulpgulpdotRuntime.parseString(p_name);
		const mime = GulpgulpgulpdotRuntime.parseString(p_mime);
		const blob = new Blob([buf], { type: mime });
		const url = window.URL.createObjectURL(blob);
		const a = document.createElement('a');
		a.href = url;
		a.download = name;
		a.style.display = 'none';
		document.body.appendChild(a);
		a.click();
		a.remove();
		window.URL.revokeObjectURL(url);
	},
};

autoAddDeps(GulpgulpgulpdotOS, '$GulpgulpgulpdotOS');
mergeInto(LibraryManager.library, GulpgulpgulpdotOS);

/*
 * Gulpgulpgulpdot event listeners.
 * Keeps track of registered event listeners so it can remove them on shutdown.
 */
const GulpgulpgulpdotEventListeners = {
	$GulpgulpgulpdotEventListeners__deps: ['$GulpgulpgulpdotOS'],
	$GulpgulpgulpdotEventListeners__postset: 'GulpgulpgulpdotOS.atexit(function(resolve, reject) { GulpgulpgulpdotEventListeners.clear(); resolve(); });',
	$GulpgulpgulpdotEventListeners: {
		handlers: [],

		has: function (target, event, method, capture) {
			return GulpgulpgulpdotEventListeners.handlers.findIndex(function (e) {
				return e.target === target && e.event === event && e.method === method && e.capture === capture;
			}) !== -1;
		},

		add: function (target, event, method, capture) {
			if (GulpgulpgulpdotEventListeners.has(target, event, method, capture)) {
				return;
			}
			function Handler(p_target, p_event, p_method, p_capture) {
				this.target = p_target;
				this.event = p_event;
				this.method = p_method;
				this.capture = p_capture;
			}
			GulpgulpgulpdotEventListeners.handlers.push(new Handler(target, event, method, capture));
			target.addEventListener(event, method, capture);
		},

		clear: function () {
			GulpgulpgulpdotEventListeners.handlers.forEach(function (h) {
				h.target.removeEventListener(h.event, h.method, h.capture);
			});
			GulpgulpgulpdotEventListeners.handlers.length = 0;
		},
	},
};
mergeInto(LibraryManager.library, GulpgulpgulpdotEventListeners);

const GulpgulpgulpdotPWA = {

	$GulpgulpgulpdotPWA__deps: ['$GulpgulpgulpdotRuntime', '$GulpgulpgulpdotEventListeners'],
	$GulpgulpgulpdotPWA: {
		hasUpdate: false,

		updateState: function (cb, reg) {
			if (!reg) {
				return;
			}
			if (!reg.active) {
				return;
			}
			if (reg.waiting) {
				GulpgulpgulpdotPWA.hasUpdate = true;
				cb();
			}
			GulpgulpgulpdotEventListeners.add(reg, 'updatefound', function () {
				const installing = reg.installing;
				GulpgulpgulpdotEventListeners.add(installing, 'statechange', function () {
					if (installing.state === 'installed') {
						GulpgulpgulpdotPWA.hasUpdate = true;
						cb();
					}
				});
			});
		},
	},

	gulpgulpgulpdot_js_pwa_cb__proxy: 'sync',
	gulpgulpgulpdot_js_pwa_cb__sig: 'vi',
	gulpgulpgulpdot_js_pwa_cb: function (p_update_cb) {
		if ('serviceWorker' in navigator) {
			try {
				const cb = GulpgulpgulpdotRuntime.get_func(p_update_cb);
				navigator.serviceWorker.getRegistration().then(GulpgulpgulpdotPWA.updateState.bind(null, cb));
			} catch (e) {
				GulpgulpgulpdotRuntime.error('Failed to assign PWA callback', e);
			}
		}
	},

	gulpgulpgulpdot_js_pwa_update__proxy: 'sync',
	gulpgulpgulpdot_js_pwa_update__sig: 'i',
	gulpgulpgulpdot_js_pwa_update: function () {
		if ('serviceWorker' in navigator && GulpgulpgulpdotPWA.hasUpdate) {
			try {
				navigator.serviceWorker.getRegistration().then(function (reg) {
					if (!reg || !reg.waiting) {
						return;
					}
					reg.waiting.postMessage('update');
				});
			} catch (e) {
				GulpgulpgulpdotRuntime.error(e);
				return 1;
			}
			return 0;
		}
		return 1;
	},
};

autoAddDeps(GulpgulpgulpdotPWA, '$GulpgulpgulpdotPWA');
mergeInto(LibraryManager.library, GulpgulpgulpdotPWA);
