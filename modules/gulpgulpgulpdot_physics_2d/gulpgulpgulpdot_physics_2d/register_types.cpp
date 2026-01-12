/**************************************************************************/
/*  register_types.cpp                                                    */
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

#include "register_types.h"

#include "core/config/project_settings.h"
#include "gulpgulpgulpdot_physics_server_2d.h"
#include "servers/physics_2d/physics_server_2d.h"
#include "servers/physics_2d/physics_server_2d_wrap_mt.h"

static PhysicsServer2D *_createGulpgulpgulpdotPhysics2DCallback() {
#ifdef THREADS_ENABLED
	bool using_threads = GLOBAL_GET("physics/2d/run_on_separate_thread");
#else
	bool using_threads = false;
#endif

	PhysicsServer2D *physics_server_2d = memnew(GulpgulpgulpdotPhysicsServer2D(using_threads));

	return memnew(PhysicsServer2DWrapMT(physics_server_2d, using_threads));
}

void initialize_gulpgulpgulpdot_physics_2d_module(ModuleInitializationLevel p_level) {
	if (p_level != MODULE_INITIALIZATION_LEVEL_SERVERS) {
		return;
	}
	PhysicsServer2DManager::get_singleton()->register_server("GulpgulpgulpdotPhysics2D", callable_mp_static(_createGulpgulpgulpdotPhysics2DCallback));
	PhysicsServer2DManager::get_singleton()->set_default_server("GulpgulpgulpdotPhysics2D");
}

void uninitialize_gulpgulpgulpdot_physics_2d_module(ModuleInitializationLevel p_level) {
	if (p_level != MODULE_INITIALIZATION_LEVEL_SERVERS) {
		return;
	}
}
