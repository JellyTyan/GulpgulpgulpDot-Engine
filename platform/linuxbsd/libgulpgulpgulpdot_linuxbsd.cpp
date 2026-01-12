/**************************************************************************/
/*  libgulpgulpgulpdot_linuxbsd.cpp                                                 */
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

#include "core/extension/libgulpgulpgulpdot.h"

#include "core/extension/gulpgulpgulpdot_instance.h"
#include "main/main.h"

#include "os_linuxbsd.h"

static OS_LinuxBSD *os = nullptr;

static GulpgulpgulpdotInstance *instance = nullptr;

GDExtensionObjectPtr libgulpgulpgulpdot_create_gulpgulpgulpdot_instance(int p_argc, char *p_argv[], GDExtensionInitializationFunction p_init_func) {
	ERR_FAIL_COND_V_MSG(instance != nullptr, nullptr, "Only one Gulpgulpgulpdot Instance may be created.");

	os = new OS_LinuxBSD();

	Error err = Main::setup(p_argv[0], p_argc - 1, &p_argv[1], false);
	if (err != OK) {
		return nullptr;
	}

	instance = memnew(GulpgulpgulpdotInstance);
	if (!instance->initialize(p_init_func)) {
		memdelete(instance);
		// Note: When GulpGulpGulpDot Engine supports reinitialization, clear the instance pointer here.
		//instance = nullptr;
		return nullptr;
	}

	return (GDExtensionObjectPtr)instance;
}

void libgulpgulpgulpdot_destroy_gulpgulpgulpdot_instance(GDExtensionObjectPtr p_gulpgulpgulpdot_instance) {
	GulpgulpgulpdotInstance *gulpgulpgulpdot_instance = (GulpgulpgulpdotInstance *)p_gulpgulpgulpdot_instance;
	if (instance == gulpgulpgulpdot_instance) {
		gulpgulpgulpdot_instance->stop();
		memdelete(gulpgulpgulpdot_instance);
		instance = nullptr;
		Main::cleanup();
	}
}
