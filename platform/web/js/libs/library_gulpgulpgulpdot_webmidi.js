/**************************************************************************/
/*  library_gulpgulpgulpdot_webmidi.js                                              */
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

const GulpgulpgulpdotWebMidi = {

	$GulpgulpgulpdotWebMidi__deps: ['$GulpgulpgulpdotRuntime'],
	$GulpgulpgulpdotWebMidi: {
		abortControllers: [],
		isListening: false,
	},

	gulpgulpgulpdot_js_webmidi_open_midi_inputs__deps: ['$GulpgulpgulpdotWebMidi'],
	gulpgulpgulpdot_js_webmidi_open_midi_inputs__proxy: 'sync',
	gulpgulpgulpdot_js_webmidi_open_midi_inputs__sig: 'iiii',
	gulpgulpgulpdot_js_webmidi_open_midi_inputs: function (pSetInputNamesCb, pOnMidiMessageCb, pDataBuffer, dataBufferLen) {
		if (GulpgulpgulpdotWebMidi.is_listening) {
			return 0; // OK
		}
		if (!navigator.requestMIDIAccess) {
			return 2; // ERR_UNAVAILABLE
		}
		const setInputNamesCb = GulpgulpgulpdotRuntime.get_func(pSetInputNamesCb);
		const onMidiMessageCb = GulpgulpgulpdotRuntime.get_func(pOnMidiMessageCb);

		GulpgulpgulpdotWebMidi.isListening = true;
		navigator.requestMIDIAccess().then((midi) => {
			const inputs = [...midi.inputs.values()];
			const inputNames = inputs.map((input) => input.name);

			const c_ptr = GulpgulpgulpdotRuntime.allocStringArray(inputNames);
			setInputNamesCb(inputNames.length, c_ptr);
			GulpgulpgulpdotRuntime.freeStringArray(c_ptr, inputNames.length);

			inputs.forEach((input, i) => {
				const abortController = new AbortController();
				GulpgulpgulpdotWebMidi.abortControllers.push(abortController);
				input.addEventListener('midimessage', (event) => {
					const status = event.data[0];
					const data = event.data.slice(1);
					const size = data.length;

					if (size > dataBufferLen) {
						throw new Error(`data too big ${size} > ${dataBufferLen}`);
					}
					HEAPU8.set(data, pDataBuffer);

					onMidiMessageCb(i, status, pDataBuffer, data.length);
				}, { signal: abortController.signal });
			});
		});

		return 0; // OK
	},

	gulpgulpgulpdot_js_webmidi_close_midi_inputs__deps: ['$GulpgulpgulpdotWebMidi'],
	gulpgulpgulpdot_js_webmidi_close_midi_inputs__proxy: 'sync',
	gulpgulpgulpdot_js_webmidi_close_midi_inputs__sig: 'v',
	gulpgulpgulpdot_js_webmidi_close_midi_inputs: function () {
		for (const abortController of GulpgulpgulpdotWebMidi.abortControllers) {
			abortController.abort();
		}
		GulpgulpgulpdotWebMidi.abortControllers = [];
		GulpgulpgulpdotWebMidi.isListening = false;
	},
};

mergeInto(LibraryManager.library, GulpgulpgulpdotWebMidi);
