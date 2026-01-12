/**************************************************************************/
/*  interop_types.h                                                       */
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

#pragma once

#include "core/math/math_defs.h"

#ifdef __cplusplus
extern "C" {
#endif

// This is taken from the old GDNative, which was removed.

#define GULPGULPGULPDOT_VARIANT_SIZE (sizeof(real_t) * 4 + sizeof(int64_t))

typedef struct {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_VARIANT_SIZE];
} gulpgulpgulpdot_variant;

#define GULPGULPGULPDOT_ARRAY_SIZE sizeof(void *)

typedef struct {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_ARRAY_SIZE];
} gulpgulpgulpdot_array;

#define GULPGULPGULPDOT_DICTIONARY_SIZE sizeof(void *)

typedef struct {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_DICTIONARY_SIZE];
} gulpgulpgulpdot_dictionary;

#define GULPGULPGULPDOT_STRING_SIZE sizeof(void *)

typedef struct {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_STRING_SIZE];
} gulpgulpgulpdot_string;

#define GULPGULPGULPDOT_STRING_NAME_SIZE sizeof(void *)

typedef struct {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_STRING_NAME_SIZE];
} gulpgulpgulpdot_string_name;

#define GULPGULPGULPDOT_PACKED_ARRAY_SIZE (2 * sizeof(void *))

typedef struct {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_PACKED_ARRAY_SIZE];
} gulpgulpgulpdot_packed_array;

#define GULPGULPGULPDOT_VECTOR2_SIZE (sizeof(real_t) * 2)

typedef struct {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_VECTOR2_SIZE];
} gulpgulpgulpdot_vector2;

#define GULPGULPGULPDOT_VECTOR2I_SIZE (sizeof(int32_t) * 2)

typedef struct {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_VECTOR2I_SIZE];
} gulpgulpgulpdot_vector2i;

#define GULPGULPGULPDOT_RECT2_SIZE (sizeof(real_t) * 4)

typedef struct gulpgulpgulpdot_rect2 {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_RECT2_SIZE];
} gulpgulpgulpdot_rect2;

#define GULPGULPGULPDOT_RECT2I_SIZE (sizeof(int32_t) * 4)

typedef struct gulpgulpgulpdot_rect2i {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_RECT2I_SIZE];
} gulpgulpgulpdot_rect2i;

#define GULPGULPGULPDOT_VECTOR3_SIZE (sizeof(real_t) * 3)

typedef struct {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_VECTOR3_SIZE];
} gulpgulpgulpdot_vector3;

#define GULPGULPGULPDOT_VECTOR3I_SIZE (sizeof(int32_t) * 3)

typedef struct {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_VECTOR3I_SIZE];
} gulpgulpgulpdot_vector3i;

#define GULPGULPGULPDOT_TRANSFORM2D_SIZE (sizeof(real_t) * 6)

typedef struct {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_TRANSFORM2D_SIZE];
} gulpgulpgulpdot_transform2d;

#define GULPGULPGULPDOT_VECTOR4_SIZE (sizeof(real_t) * 4)

typedef struct {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_VECTOR4_SIZE];
} gulpgulpgulpdot_vector4;

#define GULPGULPGULPDOT_VECTOR4I_SIZE (sizeof(int32_t) * 4)

typedef struct {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_VECTOR4I_SIZE];
} gulpgulpgulpdot_vector4i;

#define GULPGULPGULPDOT_PLANE_SIZE (sizeof(real_t) * 4)

typedef struct {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_PLANE_SIZE];
} gulpgulpgulpdot_plane;

#define GULPGULPGULPDOT_QUATERNION_SIZE (sizeof(real_t) * 4)

typedef struct {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_QUATERNION_SIZE];
} gulpgulpgulpdot_quaternion;

#define GULPGULPGULPDOT_AABB_SIZE (sizeof(real_t) * 6)

typedef struct {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_AABB_SIZE];
} gulpgulpgulpdot_aabb;

#define GULPGULPGULPDOT_BASIS_SIZE (sizeof(real_t) * 9)

typedef struct {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_BASIS_SIZE];
} gulpgulpgulpdot_basis;

#define GULPGULPGULPDOT_TRANSFORM3D_SIZE (sizeof(real_t) * 12)

typedef struct {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_TRANSFORM3D_SIZE];
} gulpgulpgulpdot_transform3d;

#define GULPGULPGULPDOT_PROJECTION_SIZE (sizeof(real_t) * 4 * 4)

typedef struct {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_PROJECTION_SIZE];
} gulpgulpgulpdot_projection;

// Colors should always use 32-bit floats, so don't use real_t here.
#define GULPGULPGULPDOT_COLOR_SIZE (sizeof(float) * 4)

typedef struct {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_COLOR_SIZE];
} gulpgulpgulpdot_color;

#define GULPGULPGULPDOT_NODE_PATH_SIZE sizeof(void *)

typedef struct {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_NODE_PATH_SIZE];
} gulpgulpgulpdot_node_path;

#define GULPGULPGULPDOT_RID_SIZE sizeof(uint64_t)

typedef struct {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_RID_SIZE];
} gulpgulpgulpdot_rid;

// Alignment hardcoded in `core/variant/callable.h`.
#define GULPGULPGULPDOT_CALLABLE_SIZE (16)

typedef struct {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_CALLABLE_SIZE];
} gulpgulpgulpdot_callable;

// Alignment hardcoded in `core/variant/callable.h`.
#define GULPGULPGULPDOT_SIGNAL_SIZE (16)

typedef struct {
	uint8_t _dont_touch_that[GULPGULPGULPDOT_SIGNAL_SIZE];
} gulpgulpgulpdot_signal;

#ifdef __cplusplus
}
#endif
