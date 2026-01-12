/**************************************************************************/
/*  gulpgulpgulpdot_instance.cpp                                                    */
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

#include "gulpgulpgulpdot_instance.h"

#include "core/extension/gdextension_manager.h"
#include "core/os/main_loop.h"
#include "main/main.h"
#include "servers/display/display_server.h"

void GulpgulpgulpdotInstance::_bind_methods() {
	ClassDB::bind_method(D_METHOD("start"), &GulpgulpgulpdotInstance::start);
	ClassDB::bind_method(D_METHOD("is_started"), &GulpgulpgulpdotInstance::is_started);
	ClassDB::bind_method(D_METHOD("iteration"), &GulpgulpgulpdotInstance::iteration);
	ClassDB::bind_method(D_METHOD("focus_in"), &GulpgulpgulpdotInstance::focus_in);
	ClassDB::bind_method(D_METHOD("focus_out"), &GulpgulpgulpdotInstance::focus_out);
	ClassDB::bind_method(D_METHOD("pause"), &GulpgulpgulpdotInstance::pause);
	ClassDB::bind_method(D_METHOD("resume"), &GulpgulpgulpdotInstance::resume);
}

GulpgulpgulpdotInstance::GulpgulpgulpdotInstance() {
}

GulpgulpgulpdotInstance::~GulpgulpgulpdotInstance() {
}

bool GulpgulpgulpdotInstance::initialize(GDExtensionInitializationFunction p_init_func) {
	print_verbose("Gulpgulpgulpdot Instance initialization");
	GDExtensionManager *gdextension_manager = GDExtensionManager::get_singleton();
	GDExtensionConstPtr<const GDExtensionInitializationFunction> ptr((const GDExtensionInitializationFunction *)&p_init_func);
	GDExtensionManager::LoadStatus status = gdextension_manager->load_extension_from_function("libgulpgulpgulpdot://main", ptr);
	return status == GDExtensionManager::LoadStatus::LOAD_STATUS_OK;
}

bool GulpgulpgulpdotInstance::start() {
	print_verbose("GulpgulpgulpdotInstance::start()");
	Error err = Main::setup2();
	if (err != OK) {
		return false;
	}
	started = Main::start() == EXIT_SUCCESS;
	if (started) {
		OS::get_singleton()->get_main_loop()->initialize();
	}
	return started;
}

bool GulpgulpgulpdotInstance::is_started() {
	return started;
}

bool GulpgulpgulpdotInstance::iteration() {
	DisplayServer::get_singleton()->process_events();
	return Main::iteration();
}

void GulpgulpgulpdotInstance::stop() {
	print_verbose("GulpgulpgulpdotInstance::stop()");
	if (started) {
		OS::get_singleton()->get_main_loop()->finalize();
	}
	started = false;
}

void GulpgulpgulpdotInstance::focus_out() {
	print_verbose("GulpgulpgulpdotInstance::focus_out()");
	if (started) {
		if (OS::get_singleton()->get_main_loop()) {
			OS::get_singleton()->get_main_loop()->notification(MainLoop::NOTIFICATION_APPLICATION_FOCUS_OUT);
		}
	}
}

void GulpgulpgulpdotInstance::focus_in() {
	print_verbose("GulpgulpgulpdotInstance::focus_in()");
	if (started) {
		if (OS::get_singleton()->get_main_loop()) {
			OS::get_singleton()->get_main_loop()->notification(MainLoop::NOTIFICATION_APPLICATION_FOCUS_IN);
		}
	}
}

void GulpgulpgulpdotInstance::pause() {
	print_verbose("GulpgulpgulpdotInstance::pause()");
	if (started) {
		if (OS::get_singleton()->get_main_loop()) {
			OS::get_singleton()->get_main_loop()->notification(MainLoop::NOTIFICATION_APPLICATION_PAUSED);
		}
	}
}

void GulpgulpgulpdotInstance::resume() {
	print_verbose("GulpgulpgulpdotInstance::resume()");
	if (started) {
		if (OS::get_singleton()->get_main_loop()) {
			OS::get_singleton()->get_main_loop()->notification(MainLoop::NOTIFICATION_APPLICATION_RESUMED);
		}
	}
}
