/**************************************************************************/
/*  library_gulpgulpgulpdot_websocket.js                                            */
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

const GulpgulpgulpdotWebSocket = {
	// Our socket implementation that forwards events to C++.
	$GulpgulpgulpdotWebSocket__deps: ['$IDHandler', '$GulpgulpgulpdotRuntime'],
	$GulpgulpgulpdotWebSocket: {
		// Connection opened, report selected protocol
		_onopen: function (p_id, callback, event) {
			const ref = IDHandler.get(p_id);
			if (!ref) {
				return; // Gulpgulpgulpdot object is gone.
			}
			const c_str = GulpgulpgulpdotRuntime.allocString(ref.protocol);
			callback(c_str);
			GulpgulpgulpdotRuntime.free(c_str);
		},

		// Message received, report content and type (UTF8 vs binary)
		_onmessage: function (p_id, callback, event) {
			const ref = IDHandler.get(p_id);
			if (!ref) {
				return; // Gulpgulpgulpdot object is gone.
			}
			let buffer;
			let is_string = 0;
			if (event.data instanceof ArrayBuffer) {
				buffer = new Uint8Array(event.data);
			} else if (event.data instanceof Blob) {
				GulpgulpgulpdotRuntime.error('Blob type not supported');
				return;
			} else if (typeof event.data === 'string') {
				is_string = 1;
				buffer = new TextEncoder('utf-8').encode(event.data);
			} else {
				GulpgulpgulpdotRuntime.error('Unknown message type');
				return;
			}
			const len = buffer.length * buffer.BYTES_PER_ELEMENT;
			const out = GulpgulpgulpdotRuntime.malloc(len);
			HEAPU8.set(buffer, out);
			callback(out, len, is_string);
			GulpgulpgulpdotRuntime.free(out);
		},

		// An error happened, 'onclose' will be called after this.
		_onerror: function (p_id, callback, event) {
			const ref = IDHandler.get(p_id);
			if (!ref) {
				return; // Gulpgulpgulpdot object is gone.
			}
			callback();
		},

		// Connection is closed, this is always fired. Report close code, reason, and clean status.
		_onclose: function (p_id, callback, event) {
			const ref = IDHandler.get(p_id);
			if (!ref) {
				return; // Gulpgulpgulpdot object is gone.
			}
			const c_str = GulpgulpgulpdotRuntime.allocString(event.reason);
			callback(event.code, c_str, event.wasClean ? 1 : 0);
			GulpgulpgulpdotRuntime.free(c_str);
		},

		// Send a message
		send: function (p_id, p_data) {
			const ref = IDHandler.get(p_id);
			if (!ref || ref.readyState !== ref.OPEN) {
				return 1; // Gulpgulpgulpdot object is gone or socket is not in a ready state.
			}
			ref.send(p_data);
			return 0;
		},

		// Get current bufferedAmount
		bufferedAmount: function (p_id) {
			const ref = IDHandler.get(p_id);
			if (!ref) {
				return 0; // Gulpgulpgulpdot object is gone.
			}
			return ref.bufferedAmount;
		},

		create: function (socket, p_on_open, p_on_message, p_on_error, p_on_close) {
			const id = IDHandler.add(socket);
			socket.onopen = GulpgulpgulpdotWebSocket._onopen.bind(null, id, p_on_open);
			socket.onmessage = GulpgulpgulpdotWebSocket._onmessage.bind(null, id, p_on_message);
			socket.onerror = GulpgulpgulpdotWebSocket._onerror.bind(null, id, p_on_error);
			socket.onclose = GulpgulpgulpdotWebSocket._onclose.bind(null, id, p_on_close);
			return id;
		},

		// Closes the JavaScript WebSocket (if not already closing) associated to a given C++ object.
		close: function (p_id, p_code, p_reason) {
			const ref = IDHandler.get(p_id);
			if (ref && ref.readyState < ref.CLOSING) {
				const code = p_code;
				const reason = p_reason;
				ref.close(code, reason);
			}
		},

		// Deletes the reference to a C++ object (closing any connected socket if necessary).
		destroy: function (p_id) {
			const ref = IDHandler.get(p_id);
			if (!ref) {
				return;
			}
			GulpgulpgulpdotWebSocket.close(p_id, 3001, 'destroyed');
			IDHandler.remove(p_id);
			ref.onopen = null;
			ref.onmessage = null;
			ref.onerror = null;
			ref.onclose = null;
		},
	},

	gulpgulpgulpdot_js_websocket_create__proxy: 'sync',
	gulpgulpgulpdot_js_websocket_create__sig: 'iiiiiiii',
	gulpgulpgulpdot_js_websocket_create: function (p_ref, p_url, p_proto, p_on_open, p_on_message, p_on_error, p_on_close) {
		const on_open = GulpgulpgulpdotRuntime.get_func(p_on_open).bind(null, p_ref);
		const on_message = GulpgulpgulpdotRuntime.get_func(p_on_message).bind(null, p_ref);
		const on_error = GulpgulpgulpdotRuntime.get_func(p_on_error).bind(null, p_ref);
		const on_close = GulpgulpgulpdotRuntime.get_func(p_on_close).bind(null, p_ref);
		const url = GulpgulpgulpdotRuntime.parseString(p_url);
		const protos = GulpgulpgulpdotRuntime.parseString(p_proto);
		let socket = null;
		try {
			if (protos) {
				socket = new WebSocket(url, protos.split(','));
			} else {
				socket = new WebSocket(url);
			}
		} catch (e) {
			return 0;
		}
		socket.binaryType = 'arraybuffer';
		return GulpgulpgulpdotWebSocket.create(socket, on_open, on_message, on_error, on_close);
	},

	gulpgulpgulpdot_js_websocket_send__proxy: 'sync',
	gulpgulpgulpdot_js_websocket_send__sig: 'iiiii',
	gulpgulpgulpdot_js_websocket_send: function (p_id, p_buf, p_buf_len, p_raw) {
		const bytes_array = new Uint8Array(p_buf_len);
		let i = 0;
		for (i = 0; i < p_buf_len; i++) {
			bytes_array[i] = GulpgulpgulpdotRuntime.getHeapValue(p_buf + i, 'i8');
		}
		let out = bytes_array.buffer;
		if (!p_raw) {
			out = new TextDecoder('utf-8').decode(bytes_array);
		}
		return GulpgulpgulpdotWebSocket.send(p_id, out);
	},

	gulpgulpgulpdot_js_websocket_buffered_amount__proxy: 'sync',
	gulpgulpgulpdot_js_websocket_buffered_amount__sig: 'ii',
	gulpgulpgulpdot_js_websocket_buffered_amount: function (p_id) {
		return GulpgulpgulpdotWebSocket.bufferedAmount(p_id);
	},

	gulpgulpgulpdot_js_websocket_close__proxy: 'sync',
	gulpgulpgulpdot_js_websocket_close__sig: 'viii',
	gulpgulpgulpdot_js_websocket_close: function (p_id, p_code, p_reason) {
		const code = p_code;
		const reason = GulpgulpgulpdotRuntime.parseString(p_reason);
		GulpgulpgulpdotWebSocket.close(p_id, code, reason);
	},

	gulpgulpgulpdot_js_websocket_destroy__proxy: 'sync',
	gulpgulpgulpdot_js_websocket_destroy__sig: 'vi',
	gulpgulpgulpdot_js_websocket_destroy: function (p_id) {
		GulpgulpgulpdotWebSocket.destroy(p_id);
	},
};

autoAddDeps(GulpgulpgulpdotWebSocket, '$GulpgulpgulpdotWebSocket');
mergeInto(LibraryManager.library, GulpgulpgulpdotWebSocket);
