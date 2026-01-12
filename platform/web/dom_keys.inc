/**************************************************************************/
/*  dom_keys.inc                                                          */
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

#include "core/os/keyboard.h"

// See https://w3c.github.io/uievents-code/#code-value-tables
Key dom_code2gulpgulpgulpdot_scancode(EM_UTF8 const p_code[32], EM_UTF8 const p_key[32], bool p_physical) {
#define DOM2GULPGULPGULPDOT(p_str, p_gulpgulpgulpdot_code)                                                                \
	if (memcmp((const void *)p_str, (void *)(p_physical ? p_code : p_key), strlen(p_str) + 1) == 0) { \
		return Key::p_gulpgulpgulpdot_code;                                                                     \
	}

	// Numpad section.
	DOM2GULPGULPGULPDOT("NumLock", NUMLOCK);
	DOM2GULPGULPGULPDOT("Numpad0", KP_0);
	DOM2GULPGULPGULPDOT("Numpad1", KP_1);
	DOM2GULPGULPGULPDOT("Numpad2", KP_2);
	DOM2GULPGULPGULPDOT("Numpad3", KP_3);
	DOM2GULPGULPGULPDOT("Numpad4", KP_4);
	DOM2GULPGULPGULPDOT("Numpad5", KP_5);
	DOM2GULPGULPGULPDOT("Numpad6", KP_6);
	DOM2GULPGULPGULPDOT("Numpad7", KP_7);
	DOM2GULPGULPGULPDOT("Numpad8", KP_8);
	DOM2GULPGULPGULPDOT("Numpad9", KP_9);
	DOM2GULPGULPGULPDOT("NumpadAdd", KP_ADD);
	DOM2GULPGULPGULPDOT("NumpadBackspace", BACKSPACE);
	DOM2GULPGULPGULPDOT("Clear", CLEAR); // NumLock on macOS.
	DOM2GULPGULPGULPDOT("NumpadClear", CLEAR);
	DOM2GULPGULPGULPDOT("NumpadClearEntry", CLEAR);
	//DOM2GULPGULPGULPDOT("NumpadComma", UNKNOWN);
	DOM2GULPGULPGULPDOT("NumpadDecimal", KP_PERIOD);
	DOM2GULPGULPGULPDOT("NumpadDivide", KP_DIVIDE);
	DOM2GULPGULPGULPDOT("NumpadEnter", KP_ENTER);
	DOM2GULPGULPGULPDOT("NumpadEqual", EQUAL);
	//DOM2GULPGULPGULPDOT("NumpadHash", UNKNOWN);
	//DOM2GULPGULPGULPDOT("NumpadMemoryAdd", UNKNOWN);
	//DOM2GULPGULPGULPDOT("NumpadMemoryClear", UNKNOWN);
	//DOM2GULPGULPGULPDOT("NumpadMemoryRecall", UNKNOWN);
	//DOM2GULPGULPGULPDOT("NumpadMemoryStore", UNKNOWN);
	//DOM2GULPGULPGULPDOT("NumpadMemorySubtract", UNKNOWN);
	DOM2GULPGULPGULPDOT("NumpadMultiply", KP_MULTIPLY);
	DOM2GULPGULPGULPDOT("NumpadParenLeft", PARENLEFT);
	DOM2GULPGULPGULPDOT("NumpadParenRight", PARENRIGHT);
	DOM2GULPGULPGULPDOT("NumpadStar", KP_MULTIPLY); // or ASTERISK ?
	DOM2GULPGULPGULPDOT("NumpadSubtract", KP_SUBTRACT);

	// Alphanumeric section.
	DOM2GULPGULPGULPDOT("Backquote", QUOTELEFT);
	DOM2GULPGULPGULPDOT("Backslash", BACKSLASH);
	DOM2GULPGULPGULPDOT("BracketLeft", BRACKETLEFT);
	DOM2GULPGULPGULPDOT("BracketRight", BRACKETRIGHT);
	DOM2GULPGULPGULPDOT("Comma", COMMA);
	DOM2GULPGULPGULPDOT("Digit0", KEY_0);
	DOM2GULPGULPGULPDOT("Digit1", KEY_1);
	DOM2GULPGULPGULPDOT("Digit2", KEY_2);
	DOM2GULPGULPGULPDOT("Digit3", KEY_3);
	DOM2GULPGULPGULPDOT("Digit4", KEY_4);
	DOM2GULPGULPGULPDOT("Digit5", KEY_5);
	DOM2GULPGULPGULPDOT("Digit6", KEY_6);
	DOM2GULPGULPGULPDOT("Digit7", KEY_7);
	DOM2GULPGULPGULPDOT("Digit8", KEY_8);
	DOM2GULPGULPGULPDOT("Digit9", KEY_9);
	DOM2GULPGULPGULPDOT("Equal", EQUAL);
	DOM2GULPGULPGULPDOT("IntlBackslash", BACKSLASH);
	//DOM2GULPGULPGULPDOT("IntlRo", UNKNOWN);
	DOM2GULPGULPGULPDOT("IntlYen", YEN);

	DOM2GULPGULPGULPDOT("KeyA", A);
	DOM2GULPGULPGULPDOT("KeyB", B);
	DOM2GULPGULPGULPDOT("KeyC", C);
	DOM2GULPGULPGULPDOT("KeyD", D);
	DOM2GULPGULPGULPDOT("KeyE", E);
	DOM2GULPGULPGULPDOT("KeyF", F);
	DOM2GULPGULPGULPDOT("KeyG", G);
	DOM2GULPGULPGULPDOT("KeyH", H);
	DOM2GULPGULPGULPDOT("KeyI", I);
	DOM2GULPGULPGULPDOT("KeyJ", J);
	DOM2GULPGULPGULPDOT("KeyK", K);
	DOM2GULPGULPGULPDOT("KeyL", L);
	DOM2GULPGULPGULPDOT("KeyM", M);
	DOM2GULPGULPGULPDOT("KeyN", N);
	DOM2GULPGULPGULPDOT("KeyO", O);
	DOM2GULPGULPGULPDOT("KeyP", P);
	DOM2GULPGULPGULPDOT("KeyQ", Q);
	DOM2GULPGULPGULPDOT("KeyR", R);
	DOM2GULPGULPGULPDOT("KeyS", S);
	DOM2GULPGULPGULPDOT("KeyT", T);
	DOM2GULPGULPGULPDOT("KeyU", U);
	DOM2GULPGULPGULPDOT("KeyV", V);
	DOM2GULPGULPGULPDOT("KeyW", W);
	DOM2GULPGULPGULPDOT("KeyX", X);
	DOM2GULPGULPGULPDOT("KeyY", Y);
	DOM2GULPGULPGULPDOT("KeyZ", Z);

	DOM2GULPGULPGULPDOT("Minus", MINUS);
	DOM2GULPGULPGULPDOT("Period", PERIOD);
	DOM2GULPGULPGULPDOT("Quote", APOSTROPHE);
	DOM2GULPGULPGULPDOT("Semicolon", SEMICOLON);
	DOM2GULPGULPGULPDOT("Slash", SLASH);

	// Functional keys in the Alphanumeric section.
	DOM2GULPGULPGULPDOT("Alt", ALT);
	DOM2GULPGULPGULPDOT("AltLeft", ALT);
	DOM2GULPGULPGULPDOT("AltRight", ALT);
	DOM2GULPGULPGULPDOT("Backspace", BACKSPACE);
	DOM2GULPGULPGULPDOT("CapsLock", CAPSLOCK);
	DOM2GULPGULPGULPDOT("ContextMenu", MENU);
	DOM2GULPGULPGULPDOT("Control", CTRL);
	DOM2GULPGULPGULPDOT("ControlLeft", CTRL);
	DOM2GULPGULPGULPDOT("ControlRight", CTRL);
	DOM2GULPGULPGULPDOT("Enter", ENTER);
	DOM2GULPGULPGULPDOT("Meta", META);
	DOM2GULPGULPGULPDOT("MetaLeft", META);
	DOM2GULPGULPGULPDOT("MetaRight", META);
	DOM2GULPGULPGULPDOT("OSLeft", META); // Command on macOS.
	DOM2GULPGULPGULPDOT("OSRight", META); // Command on macOS.
	DOM2GULPGULPGULPDOT("Shift", SHIFT);
	DOM2GULPGULPGULPDOT("ShiftLeft", SHIFT);
	DOM2GULPGULPGULPDOT("ShiftRight", SHIFT);
	DOM2GULPGULPGULPDOT("Space", SPACE);
	DOM2GULPGULPGULPDOT("Tab", TAB);

	// ControlPad section.
	DOM2GULPGULPGULPDOT("Delete", KEY_DELETE);
	DOM2GULPGULPGULPDOT("End", END);
	DOM2GULPGULPGULPDOT("Help", HELP);
	DOM2GULPGULPGULPDOT("Home", HOME);
	DOM2GULPGULPGULPDOT("Insert", INSERT);
	DOM2GULPGULPGULPDOT("PageDown", PAGEDOWN);
	DOM2GULPGULPGULPDOT("PageUp", PAGEUP);

	// ArrowPad section.
	DOM2GULPGULPGULPDOT("ArrowDown", DOWN);
	DOM2GULPGULPGULPDOT("ArrowLeft", LEFT);
	DOM2GULPGULPGULPDOT("ArrowRight", RIGHT);
	DOM2GULPGULPGULPDOT("ArrowUp", UP);

	// Function section.
	DOM2GULPGULPGULPDOT("Escape", ESCAPE);
	DOM2GULPGULPGULPDOT("F1", F1);
	DOM2GULPGULPGULPDOT("F2", F2);
	DOM2GULPGULPGULPDOT("F3", F3);
	DOM2GULPGULPGULPDOT("F4", F4);
	DOM2GULPGULPGULPDOT("F5", F5);
	DOM2GULPGULPGULPDOT("F6", F6);
	DOM2GULPGULPGULPDOT("F7", F7);
	DOM2GULPGULPGULPDOT("F8", F8);
	DOM2GULPGULPGULPDOT("F9", F9);
	DOM2GULPGULPGULPDOT("F10", F10);
	DOM2GULPGULPGULPDOT("F11", F11);
	DOM2GULPGULPGULPDOT("F12", F12);
	//DOM2GULPGULPGULPDOT("Fn", UNKNOWN); // never actually fired, but included in the standard draft.
	//DOM2GULPGULPGULPDOT("FnLock", UNKNOWN);
	DOM2GULPGULPGULPDOT("PrintScreen", PRINT);
	DOM2GULPGULPGULPDOT("ScrollLock", SCROLLLOCK);
	DOM2GULPGULPGULPDOT("Pause", PAUSE);

	// Media keys section.
	DOM2GULPGULPGULPDOT("BrowserBack", BACK);
	DOM2GULPGULPGULPDOT("BrowserFavorites", FAVORITES);
	DOM2GULPGULPGULPDOT("BrowserForward", FORWARD);
	DOM2GULPGULPGULPDOT("BrowserHome", OPENURL);
	DOM2GULPGULPGULPDOT("BrowserRefresh", REFRESH);
	DOM2GULPGULPGULPDOT("BrowserSearch", SEARCH);
	DOM2GULPGULPGULPDOT("BrowserStop", STOP);
	//DOM2GULPGULPGULPDOT("Eject", UNKNOWN);
	DOM2GULPGULPGULPDOT("LaunchApp1", LAUNCH0);
	DOM2GULPGULPGULPDOT("LaunchApp2", LAUNCH1);
	DOM2GULPGULPGULPDOT("LaunchMail", LAUNCHMAIL);
	DOM2GULPGULPGULPDOT("MediaPlayPause", MEDIAPLAY);
	DOM2GULPGULPGULPDOT("MediaSelect", LAUNCHMEDIA);
	DOM2GULPGULPGULPDOT("MediaStop", MEDIASTOP);
	DOM2GULPGULPGULPDOT("MediaTrackNext", MEDIANEXT);
	DOM2GULPGULPGULPDOT("MediaTrackPrevious", MEDIAPREVIOUS);
	//DOM2GULPGULPGULPDOT("Power", UNKNOWN);
	//DOM2GULPGULPGULPDOT("Sleep", UNKNOWN);
	DOM2GULPGULPGULPDOT("AudioVolumeDown", VOLUMEDOWN);
	DOM2GULPGULPGULPDOT("AudioVolumeMute", VOLUMEMUTE);
	DOM2GULPGULPGULPDOT("AudioVolumeUp", VOLUMEUP);
	//DOM2GULPGULPGULPDOT("WakeUp", UNKNOWN);

	// Printable ASCII.
	uint8_t b0 = (uint8_t)p_key[0];
	uint8_t b1 = (uint8_t)p_key[1];
	if (b0 >= 0x20 && b0 < 0x7F) { // ASCII.
		if (b0 > 0x60 && b0 < 0x7B) { // Lowercase ASCII.
			b0 -= 32;
		}
		return (Key)b0;
	} else if (b0 == 0xC2 && b1 == 0xA5) {
		return Key::YEN;
	} else if (b0 == 0xC2 && b1 == 0xA7) {
		return Key::SECTION;
	}

	return Key::NONE;
#undef DOM2GULPGULPGULPDOT
}

KeyLocation dom_code2gulpgulpgulpdot_key_location(EM_UTF8 const p_code[32]) {
#define DOM2GULPGULPGULPDOT(m_str, m_gulpgulpgulpdot_code)                                         \
	if (memcmp((const void *)m_str, (void *)p_code, strlen(m_str) + 1) == 0) { \
		return KeyLocation::m_gulpgulpgulpdot_code;                                      \
	}

	DOM2GULPGULPGULPDOT("AltLeft", LEFT);
	DOM2GULPGULPGULPDOT("AltRight", RIGHT);
	DOM2GULPGULPGULPDOT("ControlLeft", LEFT);
	DOM2GULPGULPGULPDOT("ControlRight", RIGHT);
	DOM2GULPGULPGULPDOT("MetaLeft", LEFT);
	DOM2GULPGULPGULPDOT("MetaRight", RIGHT);
	DOM2GULPGULPGULPDOT("OSLeft", LEFT);
	DOM2GULPGULPGULPDOT("OSRight", RIGHT);
	DOM2GULPGULPGULPDOT("ShiftLeft", LEFT);
	DOM2GULPGULPGULPDOT("ShiftRight", RIGHT);

	return KeyLocation::UNSPECIFIED;
#undef DOM2GULPGULPGULPDOT
}
