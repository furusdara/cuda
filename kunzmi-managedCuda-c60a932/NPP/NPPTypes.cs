﻿//	Copyright (c) 2012, Michael Kunz. All rights reserved.
//	http://kunzmi.github.io/managedCuda
//
//	This file is part of ManagedCuda.
//
//	ManagedCuda is free software: you can redistribute it and/or modify
//	it under the terms of the GNU Lesser General Public License as 
//	published by the Free Software Foundation, either version 2.1 of the 
//	License, or (at your option) any later version.
//
//	ManagedCuda is distributed in the hope that it will be useful,
//	but WITHOUT ANY WARRANTY; without even the implied warranty of
//	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//	GNU Lesser General Public License for more details.
//
//	You should have received a copy of the GNU Lesser General Public
//	License along with this library; if not, write to the Free Software
//	Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston,
//	MA 02110-1301  USA, http://www.gnu.org/licenses/.


using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Runtime.InteropServices;
using ManagedCuda.BasicTypes;
using ManagedCuda.VectorTypes;

namespace ManagedCuda.NPP
{
	#region Enums
	/// <summary>
	/// Filtering methods
	/// </summary>
	public enum InterpolationMode
	{
		/// <summary>
		/// Undefined
		/// </summary>
		Undefined = 0,
		/// <summary>
		/// Nearest neighbor filtering.
		/// </summary>
		NearestNeighbor = 1,
		/// <summary>
		/// Linear interpolation.
		/// </summary>
		Linear = 2,
		/// <summary>
		/// Cubic interpolation.
		/// </summary>
		Cubic = 4,
		/// <summary>
		/// Super sampling.
		/// </summary>
		SuperSampling = 8,
		/// <summary>
		/// Lanczos filtering.
		/// </summary>
		Lanczos = 16, 
		/// <summary>
		/// Generic Lanczos filtering with order 3.
		/// </summary>
		Lanczos3Advanced = 17,
		/// <summary>
		/// Smooth edge filtering.
		/// </summary>
		SmoothEdge = (1 << 31)
	}

	/// <summary>
	/// Fixed filter-kernel sizes.
	/// </summary>
	public enum MaskSize
	{
		/// <summary/>
		Size_1_X_3,
		/// <summary/>
		Size_1_X_5,
		/// <summary/>
		Size_3_X_1 = 100, // leaving space for more 1 X N type enum values 
		/// <summary/>
		Size_5_X_1,
		/// <summary/>
		Size_3_X_3 = 200, // leaving space for more N X 1 type enum values
		/// <summary/>
		Size_5_X_5,
		/// <summary/>
		Size_7_X_7 = 400,
		/// <summary/>
		Size_9_X_9 = 500,
		/// <summary/>
		Size_11_X_11 = 600,
		/// <summary/>
		Size_13_X_13 = 700,
		/// <summary/>
		Size_15_X_15 = 800
	}

	/// <summary>
	/// Error Status Codes <para/>
	/// Almost all NPP function return error-status information using
	/// these return codes.
	/// Negative return codes indicate errors, positive return codes indicate
	/// warnings, a return code of 0 indicates success.
	/// </summary>
	public enum NppStatus
	{
		// negative return-codes indicate errors
		/// <summary>
		/// 
		/// </summary>
		NotSupportedModeError = -9999,
		/// <summary/>
		InvalidHostPointerError = -1032,
		/// <summary/>
		InvalidDevicePointerError = -1031,
		/// <summary/>
		LUTPaletteBitsizeError = -1030,
		/// <summary>
		/// ZeroCrossing mode not supported
		/// </summary>
		ZCModeNotSupportedError = -1028,
		/// <summary/>
		NotSufficientComputeCapability = -1027,
		/// <summary/>
		TextureBindError = -1024,
		/// <summary/>
		WrongIntersectionRoiError = -1020,
		/// <summary/>
		HaarClassifierPixelMatchError = -1006,
		/// <summary/>
		MemfreeError = -1005,
		/// <summary/>
		MemsetError = -1004,
		/// <summary/>
		MemcpyError = -1003,
		/// <summary/>
		AlignmentError = -1002,
		/// <summary/>
		CudaKernelExecutionError = -1000,
		/// <summary>
		/// Unsupported round mode
		/// </summary>
		RoundModeNotSupportedError = -213,
		/// <summary>
		/// Image pixels are constant for quality index
		/// </summary>
		QualityIndexError = -210,
		/// <summary>
		/// One of the output image dimensions is less than 1 pixel
		/// </summary>
		ResizeNoOperationError = -201,
		/// <summary>
		/// Number overflows the upper or lower limit of the data type
		/// </summary>
		OverflowError = -109,
		/// <summary>
		/// Step value is not pixel multiple
		/// </summary>
		NotEvenStepError = -108,
		/// <summary>
		/// Number of levels for histogram is less than 2
		/// </summary>
		HistogramNumberOfLevelsError = -107,
		/// <summary>
		/// Number of levels for LUT is less than 2
		/// </summary>
		LutMumberOfLevelsError = -106,
		/// <summary>
		/// Processed data is corrupted
		/// </summary>
		CorruptedDataError = -61,
		/// <summary>
		/// Wrong order of the destination channels
		/// </summary>
		ChannelOrderError = -60,
		/// <summary>
		/// All values of the mask are zero
		/// </summary>
		ZeroMaskValueError = -59,
		/// <summary>
		/// The quadrangle is nonconvex or degenerates into triangle, line or point
		/// </summary>
		QuadrangleError = -58,
		/// <summary>
		/// Size of the rectangle region is less than or equal to 1
		/// </summary>
		RectangleError = -57,
		/// <summary>
		/// Unallowable values of the transformation coefficients
		/// </summary>
		CoefficientError = -56,
		/// <summary>
		/// Bad or unsupported number of channels
		/// </summary>
		NumberOfChannelsError = -53,
		/// <summary>
		/// Channel of interest is not 1, 2, or 3
		/// </summary>
		ChannelOfInterestError = -52,
		/// <summary>
		/// Divisor is equal to zero
		/// </summary>
		DivisorError = -51,
		/// <summary>
		/// Illegal channel index
		/// </summary>
		ChannelError = -47,
		/// <summary>
		/// Stride is less than the row length
		/// </summary>
		StrideError = -37,
		/// <summary>
		/// Anchor point is outside mask
		/// </summary>
		AnchorError = -34,
		/// <summary>
		/// Lower bound is larger than upper bound
		/// </summary>
		MaskSizeError = -33,
		/// <summary>
		/// 
		/// </summary>
		ResizeFactorError = -23,
		/// <summary>
		/// 
		/// </summary>
		InterpolationError = -22,
		/// <summary>
		/// 
		/// </summary>
		MirrorFlipError = -21,
		/// <summary>
		/// 
		/// </summary>
		Moment00ZeroErro = -20,
		/// <summary>
		/// 
		/// </summary>
		ThresholdNegativeLevelError = -19,
		/// <summary>
		/// 
		/// </summary>
		ThresholdError = -18,
		/// <summary>
		/// 
		/// </summary>
		ContextMatchError = -17,
		/// <summary>
		/// 
		/// </summary>
		FFTFlagError = -16,
		/// <summary>
		/// 
		/// </summary>
		FFTOrderError = -15,
		/// <summary>
		/// Step is less or equal zero
		/// </summary>
		StepError = -14,
		/// <summary>
		/// 
		/// </summary>
		ScaleRangeError = -13,
		/// <summary>
		/// 
		/// </summary>
		DataTypeError = -12,
		/// <summary>
		/// 
		/// </summary>
		OutOfRangeError = -11,
		/// <summary>
		/// 
		/// </summary>
		DivideByZeroError = -10,
		/// <summary>
		/// 
		/// </summary>
		MemoryAllocationError = -9,
		/// <summary>
		/// 
		/// </summary>
		NullPointerError = -8,
		/// <summary>
		/// 
		/// </summary>
		RangeError = -7,
		/// <summary>
		/// 
		/// </summary>
		SizeError = -6,
		/// <summary>
		/// 
		/// </summary>
		BadArgumentError = -5,
		/// <summary>
		/// 
		/// </summary>
		NoMemoryError = -4,
		/// <summary>
		/// 
		/// </summary>
		NotImplementedError = -3,
		/// <summary>
		/// 
		/// </summary>
		Error = -2,
		/// <summary>
		/// 
		/// </summary>
		ErrorReserved = -1,

		// success
		/// <summary>
		/// Error free operation
		/// </summary>
		NoError = 0,
		/// <summary>
		/// Successful operation (same as NoError)
		/// </summary>
		Success = NoError,

		/// <summary>
		/// Indicates that no operation was performed
		/// </summary>
		NoOperationWarning = 1,
		/// <summary>
		/// Divisor is zero however does not terminate the execution
		/// </summary>
		DivideByZeroWarning = 6,
		/// <summary>
		/// Indicates that the quadrangle passed to one of affine warping functions doesn't have necessary properties. First 3 vertices are used, the fourth vertex discarded.
		/// </summary>
		AffineQuadIncorrectWarning = 28,
		/// <summary>
		/// The given ROI has no interestion with either the source or destination ROI. Thus no operation was performed. 
		/// </summary>
		WrongIntersectionRoiWarning = 29,
		/// <summary>
		/// The given quadrangle has no intersection with either the source or destination ROI. Thus no operation was performed.
		/// </summary>
		WrongIntersectionQuadWarning = 30,
		/// <summary>
		/// Image size isn't multiple of two. Indicates that in case of 422/411/420 sampling the ROI width/height was modified for proper processing.
		/// </summary>
		DoubleSizeWarning = 35,
		/// <summary>
		/// Speed reduction due to uncoalesced memory accesses warning.
		/// </summary>
		MisalignedDstRoiWarning = 10000

	}

	/// <summary>
	/// Gpu Compute Capabilities
	/// </summary>
	public enum GpuComputeCapability
	{
		/// <summary>
		/// Indicates that the compute-capability query failed
		/// </summary>
		UnknownVersion = -1,
		/// <summary>
		/// Indicates that no CUDA capable device was found on machine
		/// </summary>
		CudaNotCapable = 0,
		/// <summary>
		/// Indicates that CUDA 1.0 capable device is default device on machine
		/// </summary>
		Cuda1_0 = 100,
		/// <summary>
		/// Indicates that CUDA 1.1 capable device
		/// </summary>
		Cuda1_1 = 110,
		/// <summary>
		/// Indicates that CUDA 1.2 capable device
		/// </summary>
		Cuda1_2 = 120,
		/// <summary>
		/// Indicates that CUDA 1.3 capable device
		/// </summary>
		Cuda1_3 = 130,
		/// <summary>
		/// Indicates that CUDA 2.0 capable device is machine's default device
		/// </summary>
		Cuda2_0 = 200,
		/// <summary>
		/// Indicates that CUDA 2.1 capable device is machine's default device
		/// </summary>
		Cuda2_1 = 210,
		/// <summary>
		/// Indicates that CUDA 3.0 capable device is machine's default device
		/// </summary>
		Cuda3_0 = 300,
		/// <summary>
		/// Indicates that CUDA 3.2 capable device is machine's default device
		/// </summary>
		Cuda3_2 = 320,
		/// <summary>
		/// Indicates that CUDA 3.5 capable device is machine's default device
		/// </summary>
		Cuda3_5 = 350,
		/// <summary>
		/// Indicates that CUDA 3.7 capable device is machine's default device
		/// </summary>
		Cuda3_7 = 370,
		/// <summary>
		/// Indicates that CUDA 5.0 capable device is machine's default device
		/// </summary>
		Cuda5_0 = 500, 
		/// <summary>
		/// Indicates that CUDA 5.2 capable device is machine's default device
		/// </summary>
		Cuda5_2 = 520,
		/// <summary>
		/// Indicates that CUDA 5.3 capable device is machine's default device
		/// </summary>
		Cuda5_3 = 530,
		/// <summary>
		/// Indicates that CUDA 6.0 or better is machine's default device
		/// </summary>
		Cuda6_0 = 600
	}

	/// <summary>
	/// Axis
	/// </summary>
	public enum NppiAxis
	{
		/// <summary>
		/// 
		/// </summary>
		Horizontal,
		/// <summary>
		/// 
		/// </summary>
		Vertical,
		/// <summary>
		/// 
		/// </summary>
		Both
	}
	
	/// <summary>
	/// Compare Operator
	/// </summary>
	public enum NppCmpOp
	{
		/// <summary>
		/// 
		/// </summary>
		Less,
		/// <summary>
		/// 
		/// </summary>
		LessEq,
		/// <summary>
		/// 
		/// </summary>
		Eq,
		/// <summary>
		/// 
		/// </summary>
		GreaterEq,
		/// <summary>
		/// 
		/// </summary>
		Greater
	}

	/// <summary>
	/// Rounding Modes<para/>
	/// The enumerated rounding modes are used by a large number of NPP primitives
	/// to allow the user to specify the method by which fractional values are converted
	/// to integer values. Also see \ref rounding_modes.<para/>
	/// For NPP release 5.5 new names for the three rounding modes are introduced that are
	/// based on the naming conventions for rounding modes set forth in the IEEE-754
	/// floating-point standard. Developers are encouraged to use the new, longer names
	/// to be future proof as the legacy names will be deprecated in subsequent NPP releases.
	/// </summary>
	public enum NppRoundMode
	{
		/// <summary>
		/// Round towards zero (truncation).<para/> 
		/// All fractional numbers of the form integer.decimals are truncated to
		/// integer.<para/>
		/// - roundZero(1.5) = 1<para/>
		/// - roundZero(1.9) = 1<para/>
		/// - roundZero(-2.5) = -2<para/>
		/// </summary>
		Zero,
		/// <summary>
		/// Round towards zero (truncation).<para/> 
		/// All fractional numbers of the form integer.decimals are truncated to
		/// integer.<para/>
		/// - roundZero(1.5) = 1<para/>
		/// - roundZero(1.9) = 1<para/>
		/// - roundZero(-2.5) = -2<para/>
		/// </summary>
		RoundTowardZero,
		/// <summary>
		/// Round to the nearest even integer.<para/>
		/// All fractional numbers are rounded to their nearest integer. The ambiguous
		/// cases (i.e. integer.5) are rounded to the closest even integer.<para/>
		/// E.g.<para/>
		/// - roundNear(0.5) = 0<para/>
		/// - roundNear(0.6) = 1<para/>
		/// - roundNear(1.5) = 2<para/>
		/// - roundNear(-1.5) = -2<para/>
		/// </summary>
		Near,
		/// <summary>
		/// Round to the nearest even integer.<para/>
		/// All fractional numbers are rounded to their nearest integer. The ambiguous
		/// cases (i.e. integer.5) are rounded to the closest even integer.<para/>
		/// E.g.<para/>
		/// - roundNear(0.5) = 0<para/>
		/// - roundNear(0.6) = 1<para/>
		/// - roundNear(1.5) = 2<para/>
		/// - roundNear(-1.5) = -2<para/>
		/// </summary>
		RoundNearestTiesToEven = Near,
		/// <summary>
		/// Round according to financial rule.<para/>
		/// All fractional numbers are rounded to their nearest integer. The ambiguous
		/// cases (i.e. integer.5) are rounded away from zero.<para/>
		/// E.g.<para/>
		/// - roundFinancial(0.4)  = 0<para/>
		/// - roundFinancial(0.5)  = 1<para/>
		/// - roundFinancial(-1.5) = -2<para/>
		/// </summary>
		Financial,
		/// <summary>
		/// Round according to financial rule.<para/>
		/// All fractional numbers are rounded to their nearest integer. The ambiguous
		/// cases (i.e. integer.5) are rounded away from zero.<para/>
		/// E.g.<para/>
		/// - roundFinancial(0.4)  = 0<para/>
		/// - roundFinancial(0.5)  = 1<para/>
		/// - roundFinancial(-1.5) = -2<para/>
		/// </summary>
		RoundNearestTiesAwayFromZero = Financial
	}

	/// <summary>
	/// BorderType
	/// </summary>
	public enum NppiBorderType
	{
		/// <summary/>
		Undefined = 0,
		/// <summary/>
		None = Undefined,
		/// <summary/>
		Constant = 1,
		/// <summary/>
		Replicate = 2,
		/// <summary/>
		Wrap = 3,
		/// <summary/>
		Mirror = 4
	} 


	/// <summary>
	/// HintAlgorithm
	/// </summary>
	public enum NppHintAlgorithm
	{
		/// <summary>
		/// 
		/// </summary>
		None,
		/// <summary>
		/// 
		/// </summary>
		Fast,
		/// <summary>
		/// 
		/// </summary>
		Accurate
	}

	/// <summary>
	/// NppiAlphaOp
	/// </summary>
	public enum NppiAlphaOp
	{
		/// <summary>
		/// 
		/// </summary>
		Over,
		/// <summary>
		/// 
		/// </summary>
		In,
		/// <summary>
		/// 
		/// </summary>
		Out,
		/// <summary>
		/// 
		/// </summary>
		Atop,
		/// <summary>
		/// 
		/// </summary>
		XOR,
		/// <summary>
		/// 
		/// </summary>
		Plus,
		/// <summary>
		/// 
		/// </summary>
		OverPremul,
		/// <summary>
		/// 
		/// </summary>
		InPremul,
		/// <summary>
		/// 
		/// </summary>
		OutPremul,
		/// <summary>
		/// 
		/// </summary>
		AtopPremul,
		/// <summary>
		/// 
		/// </summary>
		XORPremul,
		/// <summary>
		/// 
		/// </summary>
		PlusPremul,
		/// <summary>
		/// 
		/// </summary>
		Premul
	}
	
	/// <summary>
	/// NppsZCType
	/// </summary>
	public enum NppsZCType
	{
		/// <summary>
		/// sign change
		/// </summary>
		nppZCR,
		/// <summary>
		/// sign change XOR
		/// </summary>
	    nppZCXor,
		/// <summary>
		/// sign change count_0
		/// </summary>
		nppZCC 
	}

	/// <summary>
	/// NppiHuffmanTableType
	/// </summary>
	public enum NppiHuffmanTableType
	{
		/// <summary>
		/// DC Table
		/// </summary>
		nppiDCTable,
		/// <summary>
		/// AC Table
		/// </summary>
		nppiACTable,
	}

	/// <summary>
	/// Bayer Grid Position Registration.
	/// </summary>
	public enum NppiBayerGridPosition
	{
		/// <summary/>
		BGGR = 0,
		/// <summary/>            
		RGGB = 1,
		/// <summary/>
		GBRG = 2,
		/// <summary/>
		GRBG = 3
	}


	#endregion

	#region Structs
	/// <summary>
	/// Npp Library Version.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct NppLibraryVersion
	{
		/// <summary>
		/// Major version number
		/// </summary>
		public int major;
		/// <summary>
		/// Minor version number
		/// </summary>
		public int minor;
		/// <summary>
		/// Build number. This reflects the nightly build this release was made from.
		/// </summary>
		public int build;

		/// <summary>
		/// 
		/// </summary>
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "{0}.{1}.{2}", this.major, this.minor, this.build);
		}
	}

		
	/// <summary>
	/// Complex Number. <para/>
	/// This struct represents a short complex number.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct  Npp16sc
	{
		/// <summary>
		/// Real part
		/// </summary>
		short re;

		/// <summary>
		/// Imaginary part
		/// </summary>
		short im;

		/// <summary>
		/// Non-default constructor
		/// </summary>
		/// <param name="aRe"></param>
		/// <param name="aIm"></param>
		public Npp16sc(short aRe, short aIm)
		{
			re = aRe;
			im = aIm;
		}

		/// <summary>
		/// Overrides ToString(): "re + im i"
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "({0} + {1} i)", this.re, this.im);
		}
	}


	/// <summary>
	/// Complex Number. <para/>
	/// This struct represents a signed int complex number.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Npp32sc
	{
		/// <summary>
		/// Real part
		/// </summary>
		int re;

		/// <summary>
		/// Imaginary part
		/// </summary>
		int im;

		/// <summary>
		/// Non-default constructor
		/// </summary>
		/// <param name="aRe"></param>
		/// <param name="aIm"></param>
		public Npp32sc(int aRe, int aIm)
		{
			re = aRe;
			im = aIm;
		}
			
		/// <summary>
		/// Overrides ToString(): "re + im i"
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "({0} + {1} i)", this.re, this.im);
		}
	}

	/// <summary>
	/// Complex Number. <para/>
	/// This struct represents a single floating-point complex number.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Npp32fc
	{
		/// <summary>
		/// Real part
		/// </summary>
		float re;

		/// <summary>
		/// Imaginary part
		/// </summary>
		float im;

		/// <summary>
		/// Non-default constructor
		/// </summary>
		/// <param name="aRe"></param>
		/// <param name="aIm"></param>
		public Npp32fc(float aRe, float aIm)
		{
			re = aRe;
			im = aIm;
		}

		/// <summary>
		/// Overrides ToString(): "re + im i"
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "({0} + {1} i)", this.re, this.im);
		}
	} 

	/// <summary>
	/// Complex Number. <para/>
	/// This struct represents a long long complex number.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Npp64sc
	{
		/// <summary>
		/// Real part
		/// </summary>
		long re;

		/// <summary>
		/// Imaginary part
		/// </summary>
		long im;

		/// <summary>
		/// Non-default constructor
		/// </summary>
		/// <param name="aRe"></param>
		/// <param name="aIm"></param>
		public Npp64sc(long aRe, long aIm)
		{
			re = aRe;
			im = aIm;
		}

		/// <summary>
		/// Overrides ToString(): "re + im i"
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "({0} + {1} i)", this.re, this.im);
		}
	} 

	/// <summary>
	/// Complex Number. <para/>
	/// This struct represents a double floating-point complex number.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Npp64fc
	{
		/// <summary>
		/// Real part
		/// </summary>
		double  re;

		/// <summary>
		/// Imaginary part
		/// </summary>
		double im;

		/// <summary>
		/// Non-default constructor
		/// </summary>
		/// <param name="aRe"></param>
		/// <param name="aIm"></param>
		public Npp64fc(double aRe, double aIm)
		{
			re = aRe;
			im = aIm;
		}

		/// <summary>
		/// Overrides ToString(): "re + im i"
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "({0} + {1} i)", this.re, this.im);
		}
	} 

	/// <summary>
	/// 2D Point.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct NppiPoint
	{
		/// <summary>
		/// x-coordinate.
		/// </summary>
		public int x;
		/// <summary>
		/// y-coordinate.
		/// </summary>
		public int y;

		/// <summary>
		/// Non-default constructor
		/// </summary>
		/// <param name="aX"></param>
		/// <param name="aY"></param>
		public NppiPoint(int aX, int aY)
		{
			x = aX;
			y = aY;
		}

		#region Operator Methods
		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint Add(NppiPoint src, NppiPoint value)
		{
			NppiPoint ret = new NppiPoint(src.x + value.x, src.y + value.y);
			return ret;
		}
		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint Add(NppiPoint src, NppiSize value)
		{
			NppiPoint ret = new NppiPoint(src.x + value.width, src.y + value.height);
			return ret;
		}

		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint Add(NppiPoint src, int value)
		{
			NppiPoint ret = new NppiPoint(src.x + value, src.y + value);
			return ret;
		}

		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint Add(int src, NppiPoint value)
		{
			NppiPoint ret = new NppiPoint(src + value.x, src + value.y);
			return ret;
		}

		/// <summary>
		/// per element Substract
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint Subtract(NppiPoint src, NppiPoint value)
		{
			NppiPoint ret = new NppiPoint(src.x - value.x, src.y - value.y);
			return ret;
		}

		/// <summary>
		/// per element Substract
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint Subtract(NppiPoint src, NppiSize value)
		{
			NppiPoint ret = new NppiPoint(src.x - value.width, src.y - value.height);
			return ret;
		}

		/// <summary>
		/// per element Substract
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint Subtract(NppiPoint src, int value)
		{
			NppiPoint ret = new NppiPoint(src.x - value, src.y - value);
			return ret;
		}

		/// <summary>
		/// per element Substract
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint Subtract(int src, NppiPoint value)
		{
			NppiPoint ret = new NppiPoint(src - value.x, src - value.y);
			return ret;
		}

		/// <summary>
		/// per element Multiply
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint Multiply(NppiPoint src, NppiPoint value)
		{
			NppiPoint ret = new NppiPoint(src.x * value.x, src.y * value.y);
			return ret;
		}

		/// <summary>
		/// per element Multiply
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint Multiply(NppiPoint src, NppiSize value)
		{
			NppiPoint ret = new NppiPoint(src.x * value.width, src.y * value.height);
			return ret;
		}

		/// <summary>
		/// per element Multiply
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint Multiply(NppiPoint src, int value)
		{
			NppiPoint ret = new NppiPoint(src.x * value, src.y * value);
			return ret;
		}

		/// <summary>
		/// per element Multiply
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint Multiply(int src, NppiPoint value)
		{
			NppiPoint ret = new NppiPoint(src * value.x, src * value.y);
			return ret;
		}

		/// <summary>
		/// per element Divide
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint Divide(NppiPoint src, NppiPoint value)
		{
			NppiPoint ret = new NppiPoint(src.x / value.x, src.y / value.y);
			return ret;
		}

		/// <summary>
		/// per element Divide
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint Divide(NppiPoint src, NppiSize value)
		{
			NppiPoint ret = new NppiPoint(src.x / value.width, src.y / value.height);
			return ret;
		}

		/// <summary>
		/// per element Divide
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint Divide(NppiPoint src, int value)
		{
			NppiPoint ret = new NppiPoint(src.x / value, src.y / value);
			return ret;
		}

		/// <summary>
		/// per element Divide
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint Divide(int src, NppiPoint value)
		{
			NppiPoint ret = new NppiPoint(src / value.x, src / value.y);
			return ret;
		}
		#endregion

		#region operators
		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint operator +(NppiPoint src, NppiPoint value)
		{
			return Add(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint operator +(NppiPoint src, NppiSize value)
		{
			return Add(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint operator +(NppiPoint src, int value)
		{
			return Add(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint operator +(int src, NppiPoint value)
		{
			return Add(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint operator -(NppiPoint src, NppiPoint value)
		{
			return Subtract(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint operator -(NppiPoint src, NppiSize value)
		{
			return Subtract(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint operator -(NppiPoint src, int value)
		{
			return Subtract(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint operator -(int src, NppiPoint value)
		{
			return Subtract(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint operator *(NppiPoint src, NppiPoint value)
		{
			return Multiply(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint operator *(NppiPoint src, NppiSize value)
		{
			return Multiply(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint operator *(NppiPoint src, int value)
		{
			return Multiply(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint operator *(int src, NppiPoint value)
		{
			return Multiply(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint operator /(NppiPoint src, NppiPoint value)
		{
			return Divide(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint operator /(NppiPoint src, NppiSize value)
		{
			return Divide(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint operator /(NppiPoint src, int value)
		{
			return Divide(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiPoint operator /(int src, NppiPoint value)
		{
			return Divide(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool operator ==(NppiPoint src, NppiPoint value)
		{
			if (object.ReferenceEquals(src, value)) return true;
			return src.Equals(value);
		}
		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool operator !=(NppiPoint src, NppiPoint value)
		{
			return !(src == value);
		}
		#endregion

		#region Override Methods
		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (!(obj is NppiPoint)) return false;

			NppiPoint value = (NppiPoint)obj;

			bool ret = true;
			ret &= this.x == value.x;
			ret &= this.y == value.y;
			return ret;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Equals(NppiPoint value)
		{
			bool ret = true;
			ret &= this.x == value.x;
			ret &= this.y == value.y;
			return ret;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return x.GetHashCode() ^ y.GetHashCode();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "({0}; {1})", this.x, this.y);
		}
		#endregion
	}

	/// <summary>
	/// 2D Size <para/>
	/// This struct typically represents the size of a a rectangular region in
	/// two space.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct NppiSize
	{
		/// <summary>
		/// Rectangle width.
		/// </summary>
		public int width;
		/// <summary>
		/// Rectangle height.
		/// </summary>
		public int height;

		/// <summary>
		/// Non-default constructor
		/// </summary>
		/// <param name="aWidth"></param>
		/// <param name="aHeight"></param>
		public NppiSize(int aWidth, int aHeight)
		{
			width = aWidth;
			height = aHeight;
		}

		#region Operator Methods
		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiSize Add(NppiSize src, NppiSize value)
		{
			NppiSize ret = new NppiSize(src.width + value.width, src.height + value.height);
			return ret;
		}

		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiSize Add(NppiSize src, int value)
		{
			NppiSize ret = new NppiSize(src.width + value, src.height + value);
			return ret;
		}

		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiSize Add(int src, NppiSize value)
		{
			NppiSize ret = new NppiSize(src + value.width, src + value.height);
			return ret;
		}

		/// <summary>
		/// per element Substract
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiSize Subtract(NppiSize src, NppiSize value)
		{
			NppiSize ret = new NppiSize(src.width - value.width, src.height - value.height);
			return ret;
		}

		/// <summary>
		/// per element Substract
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiSize Subtract(NppiSize src, int value)
		{
			NppiSize ret = new NppiSize(src.width - value, src.height - value);
			return ret;
		}

		/// <summary>
		/// per element Substract
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiSize Subtract(int src, NppiSize value)
		{
			NppiSize ret = new NppiSize(src - value.width, src - value.height);
			return ret;
		}

		/// <summary>
		/// per element Multiply
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiSize Multiply(NppiSize src, NppiSize value)
		{
			NppiSize ret = new NppiSize(src.width * value.width, src.height * value.height);
			return ret;
		}

		/// <summary>
		/// per element Multiply
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiSize Multiply(NppiSize src, int value)
		{
			NppiSize ret = new NppiSize(src.width * value, src.height * value);
			return ret;
		}

		/// <summary>
		/// per element Multiply
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiSize Multiply(int src, NppiSize value)
		{
			NppiSize ret = new NppiSize(src * value.width, src * value.height);
			return ret;
		}

		/// <summary>
		/// per element Divide
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiSize Divide(NppiSize src, NppiSize value)
		{
			NppiSize ret = new NppiSize(src.width / value.width, src.height / value.height);
			return ret;
		}

		/// <summary>
		/// per element Divide
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiSize Divide(NppiSize src, int value)
		{
			NppiSize ret = new NppiSize(src.width / value, src.height / value);
			return ret;
		}

		/// <summary>
		/// per element Divide
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiSize Divide(int src, NppiSize value)
		{
			NppiSize ret = new NppiSize(src / value.width, src / value.height);
			return ret;
		}
		#endregion

		#region operators
		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiSize operator +(NppiSize src, NppiSize value)
		{
			return Add(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiSize operator +(NppiSize src, int value)
		{
			return Add(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiSize operator +(int src, NppiSize value)
		{
			return Add(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiSize operator -(NppiSize src, NppiSize value)
		{
			return Subtract(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiSize operator -(NppiSize src, int value)
		{
			return Subtract(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiSize operator -(int src, NppiSize value)
		{
			return Subtract(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiSize operator *(NppiSize src, NppiSize value)
		{
			return Multiply(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiSize operator *(NppiSize src, int value)
		{
			return Multiply(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiSize operator *(int src, NppiSize value)
		{
			return Multiply(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiSize operator /(NppiSize src, NppiSize value)
		{
			return Divide(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiSize operator /(NppiSize src, int value)
		{
			return Divide(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiSize operator /(int src, NppiSize value)
		{
			return Divide(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool operator ==(NppiSize src, NppiSize value)
		{
			if (object.ReferenceEquals(src, value)) return true;
			return src.Equals(value);
		}
		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool operator !=(NppiSize src, NppiSize value)
		{
			return !(src == value);
		}
		#endregion

		#region Override Methods
		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (!(obj is NppiSize)) return false;

			NppiSize value = (NppiSize)obj;

			bool ret = true;
			ret &= this.width == value.width;
			ret &= this.height == value.height;
			return ret;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Equals(NppiSize value)
		{
			bool ret = true;
			ret &= this.width == value.width;
			ret &= this.height == value.height;
			return ret;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return width.GetHashCode() ^ height.GetHashCode();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "({0}; {1})", this.width, this.height);
		}
		#endregion
	}

	/// <summary>
	/// 2D Rectangle <para/>
	/// This struct contains position and size information of a rectangle in 
	/// two space.<para/>
	/// The rectangle's position is usually signified by the coordinate of its
	/// upper-left corner.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct NppiRect
	{
		/// <summary>
		/// x-coordinate of upper left corner.
		/// </summary>
		public int x;
		/// <summary>
		/// y-coordinate of upper left corner.
		/// </summary>
		public int y;
		/// <summary>
		/// Rectangle width.
		/// </summary>
		public int width;
		/// <summary>
		/// Rectangle height.
		/// </summary>
		public int height;

		/// <summary>
		/// Non-default constructor
		/// </summary>
		/// <param name="aX"></param>
		/// <param name="aY"></param>
		/// <param name="aWidth"></param>
		/// <param name="aHeight"></param>
		public NppiRect(int aX, int aY, int aWidth, int aHeight)
		{
			x = aX;
			y = aY;
			width = aWidth;
			height = aHeight;
		}

		/// <summary>
		/// Non-default constructor
		/// </summary>
		/// <param name="aPoint"></param>
		/// <param name="aSize"></param>
		public NppiRect(NppiPoint aPoint, NppiSize aSize)
		{
			x = aPoint.x;
			y = aPoint.y;
			width = aSize.width;
			height = aSize.height;
		}

		/// <summary>
		/// Returns the x and y component as NppiPoint
		/// </summary>
		/// <returns></returns>
		public NppiPoint Location
		{
			get { return new NppiPoint(x, y); }
			set { x = value.x; y = value.y; }
		}

		/// <summary>
		/// Returns the width and height component as NppiSize
		/// </summary>
		/// <returns></returns>
		public NppiSize Size
		{
			get { return new NppiSize(width, height); }
			set { width = value.width; height = value.height; }
		}

		/// <summary>
		/// Gets the y-coordinate that is the sum of the y and height values - 1.
		/// </summary>
		public int Bottom
		{
			get { return y + height - 1; }
		}

		/// <summary>
		/// Gets the x-coordinate of the left edge.
		/// </summary>
		public int Left
		{
			get { return x; }
		}

		/// <summary>
		/// Gets the x-coordinate that is the sum of x and width values - 1.
		/// </summary>
		public int Right
		{
			get { return x + width - 1; }
		}

		/// <summary>
		/// Gets the y-coordinate of the top edge.
		/// </summary>
		public int Top
		{
			get { return y; }
		}

		/// <summary>
		/// Tests whether all numeric properties of this Rectangle have values of zero.
		/// </summary>
		public bool IsEmtpy
		{
			get { return x == 0 && y == 0 && width == 0 && height == 0; }
		}

		///// <summary>
		///// Returns the pointer shift for this roi and a given memory pitch
		///// </summary>
		///// <param name="aPitch"></param>
		///// <param name="channels"></param>
		///// <param name="typeSize"></param>
		///// <returns></returns>
		//public SizeT GetPointerShift(SizeT aPitch, int channels, int typeSize)
		//{
		//    return typeSize * channels * x + aPitch * y;
		//}

		#region Operator Methods
		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Add(NppiRect src, NppiRect value)
		{
			NppiRect ret = new NppiRect(src.x + value.x, src.y + value.y, src.width + value.width, src.height + value.height);
			return ret;
		}

		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Add(NppiRect src, int value)
		{
			NppiRect ret = new NppiRect(src.x + value, src.y + value, src.width + value, src.height + value);
			return ret;
		}

		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Add(int src, NppiRect value)
		{
			NppiRect ret = new NppiRect(src + value.x, src + value.y, src + value.width, src + value.height);
			return ret;
		}

		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Add(NppiRect src, NppiPoint value)
		{
			NppiRect ret = new NppiRect(src.x + value.x, src.y + value.y, src.width, src.height);
			return ret;
		}

		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Add(NppiPoint src, NppiRect value)
		{
			NppiRect ret = new NppiRect(src.x + value.x, src.y + value.y, value.width, value.height);
			return ret;
		}

		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Add(NppiRect src, NppiSize value)
		{
			NppiRect ret = new NppiRect(src.x, src.y, src.width + value.width, src.height + value.height);
			return ret;
		}

		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Add(NppiSize src, NppiRect value)
		{
			NppiRect ret = new NppiRect(value.x, value.y, src.width + value.width, src.height + value.height);
			return ret;
		}

		/// <summary>
		/// per element Substract
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Subtract(NppiRect src, NppiRect value)
		{
			NppiRect ret = new NppiRect(src.x - value.x, src.y - value.y, src.width - value.width, src.height - value.height);
			return ret;
		}

		/// <summary>
		/// per element Substract
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Subtract(NppiRect src, int value)
		{
			NppiRect ret = new NppiRect(src.x - value, src.y - value, src.width - value, src.height - value);
			return ret;
		}

		/// <summary>
		/// per element Substract
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Subtract(int src, NppiRect value)
		{
			NppiRect ret = new NppiRect(src - value.x, src - value.y, src - value.width, src - value.height);
			return ret;
		}

		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Subtract(NppiRect src, NppiPoint value)
		{
			NppiRect ret = new NppiRect(src.x - value.x, src.y - value.y, src.width, src.height);
			return ret;
		}

		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Subtract(NppiPoint src, NppiRect value)
		{
			NppiRect ret = new NppiRect(src.x - value.x, src.y - value.y, value.width, value.height);
			return ret;
		}

		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Subtract(NppiRect src, NppiSize value)
		{
			NppiRect ret = new NppiRect(src.x, src.y, src.width - value.width, src.height - value.height);
			return ret;
		}

		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Subtract(NppiSize src, NppiRect value)
		{
			NppiRect ret = new NppiRect(value.x, value.y, src.width - value.width, src.height - value.height);
			return ret;
		}

		/// <summary>
		/// per element Multiply
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Multiply(NppiRect src, NppiRect value)
		{
			NppiRect ret = new NppiRect(src.x * value.x, src.y * value.y, src.width * value.width, src.height * value.height);
			return ret;
		}

		/// <summary>
		/// per element Multiply
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Multiply(NppiRect src, int value)
		{
			NppiRect ret = new NppiRect(src.x * value, src.y * value, src.width * value, src.height * value);
			return ret;
		}

		/// <summary>
		/// per element Multiply
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Multiply(int src, NppiRect value)
		{
			NppiRect ret = new NppiRect(src * value.x, src * value.y, src * value.width, src * value.height);
			return ret;
		}

		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Multiply(NppiRect src, NppiPoint value)
		{
			NppiRect ret = new NppiRect(src.x * value.x, src.y * value.y, src.width, src.height);
			return ret;
		}

		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Multiply(NppiPoint src, NppiRect value)
		{
			NppiRect ret = new NppiRect(src.x * value.x, src.y * value.y, value.width, value.height);
			return ret;
		}

		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Multiply(NppiRect src, NppiSize value)
		{
			NppiRect ret = new NppiRect(src.x, src.y, src.width * value.width, src.height * value.height);
			return ret;
		}

		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Multiply(NppiSize src, NppiRect value)
		{
			NppiRect ret = new NppiRect(value.x, value.y, src.width * value.width, src.height * value.height);
			return ret;
		}

		/// <summary>
		/// per element Divide
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Divide(NppiRect src, NppiRect value)
		{
			NppiRect ret = new NppiRect(src.x / value.x, src.y / value.y, src.width / value.width, src.height / value.height);
			return ret;
		}

		/// <summary>
		/// per element Divide
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Divide(NppiRect src, int value)
		{
			NppiRect ret = new NppiRect(src.x / value, src.y / value, src.width / value, src.height / value);
			return ret;
		}

		/// <summary>
		/// per element Divide
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Divide(int src, NppiRect value)
		{
			NppiRect ret = new NppiRect(src / value.x, src / value.y, src / value.width, src / value.height);
			return ret;
		}

		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Divide(NppiRect src, NppiPoint value)
		{
			NppiRect ret = new NppiRect(src.x / value.x, src.y / value.y, src.width, src.height);
			return ret;
		}

		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Divide(NppiPoint src, NppiRect value)
		{
			NppiRect ret = new NppiRect(src.x / value.x, src.y / value.y, value.width, value.height);
			return ret;
		}

		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Divide(NppiRect src, NppiSize value)
		{
			NppiRect ret = new NppiRect(src.x, src.y, src.width / value.width, src.height / value.height);
			return ret;
		}

		/// <summary>
		/// per element Add
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect Divide(NppiSize src, NppiRect value)
		{
			NppiRect ret = new NppiRect(value.x, value.y, src.width / value.width, src.height / value.height);
			return ret;
		}
		#endregion

		#region operators
		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator +(NppiRect src, NppiRect value)
		{
			return Add(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator +(NppiRect src, int value)
		{
			return Add(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator +(int src, NppiRect value)
		{
			return Add(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator +(NppiRect src, NppiPoint value)
		{
			return Add(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator +(NppiPoint src, NppiRect value)
		{
			return Add(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator +(NppiRect src, NppiSize value)
		{
			return Add(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator +(NppiSize src, NppiRect value)
		{
			return Add(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator -(NppiRect src, NppiRect value)
		{
			return Subtract(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator -(NppiRect src, int value)
		{
			return Subtract(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator -(int src, NppiRect value)
		{
			return Subtract(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator -(NppiRect src, NppiPoint value)
		{
			return Subtract(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator -(NppiPoint src, NppiRect value)
		{
			return Subtract(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator -(NppiRect src, NppiSize value)
		{
			return Subtract(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator -(NppiSize src, NppiRect value)
		{
			return Subtract(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator *(NppiRect src, NppiRect value)
		{
			return Multiply(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator *(NppiRect src, int value)
		{
			return Multiply(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator *(int src, NppiRect value)
		{
			return Multiply(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator *(NppiRect src, NppiPoint value)
		{
			return Multiply(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator *(NppiPoint src, NppiRect value)
		{
			return Multiply(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator *(NppiRect src, NppiSize value)
		{
			return Multiply(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator *(NppiSize src, NppiRect value)
		{
			return Multiply(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator /(NppiRect src, NppiRect value)
		{
			return Divide(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator /(NppiRect src, int value)
		{
			return Divide(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator /(int src, NppiRect value)
		{
			return Divide(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator /(NppiRect src, NppiPoint value)
		{
			return Divide(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator /(NppiPoint src, NppiRect value)
		{
			return Divide(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator /(NppiRect src, NppiSize value)
		{
			return Divide(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static NppiRect operator /(NppiSize src, NppiRect value)
		{
			return Divide(src, value);
		}

		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool operator ==(NppiRect src, NppiRect value)
		{
			if (object.ReferenceEquals(src, value)) return true;
			return src.Equals(value);
		}
		/// <summary>
		/// per element
		/// </summary>
		/// <param name="src"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool operator !=(NppiRect src, NppiRect value)
		{
			return !(src == value);
		}
		#endregion

		#region Override Methods
		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (!(obj is NppiRect)) return false;

			NppiRect value = (NppiRect)obj;

			bool ret = true;
			ret &= this.x == value.x;
			ret &= this.width == value.width;
			ret &= this.y == value.y;
			ret &= this.height == value.height;
			return ret;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Equals(NppiRect value)
		{
			bool ret = true;
			ret &= this.x == value.x;
			ret &= this.width == value.width;
			ret &= this.y == value.y;
			ret &= this.height == value.height;
			return ret;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return x.GetHashCode() ^ width.GetHashCode() ^ y.GetHashCode() ^ height.GetHashCode();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "({0} + {1}; {2} + {3})", this.x, this.width, this.y, this.height);
		}
		#endregion

		#region Usefull methods
		/// <summary>
		/// Determines if the specified point is contained within this Rectangle structure.
		/// </summary>
		/// <param name="point"></param>
		/// <returns></returns>
		public bool Contains(NppiPoint point)
		{ 
			return (point.x >= Left) && (point.x <= Right) && (point.y >= Top) && (point.y <= Bottom);
		}

		/// <summary>
		/// Determines if the specified point is contained within this Rectangle structure.
		/// </summary>
		/// <param name="px"></param>
		/// <param name="py"></param>
		/// <returns></returns>
		public bool Contains(int px, int py)
		{
			return (px >= Left) && (px <= Right) && (py >= Top) && (py <= Bottom);
		}

		/// <summary>
		/// Determines if the rectangular region represented by rect is entirely contained within this Rectangle structure.
		/// </summary>
		/// <param name="rect"></param>
		/// <returns></returns>
		public bool Contains(NppiRect rect)
		{
			return Contains(rect.Location) && Contains(rect.Location + rect.Size);
		}

		/// <summary>
		/// Enlarges this Rectangle by the specified amount.
		/// </summary>
		/// <param name="val"></param>
		public void Inflate(int val)
		{
			x -= val;
			y -= val;
			width += 2 * val;
			height += 2 * val;
		}

		/// <summary>
		/// Reduces this Rectangle by the specified amount.
		/// </summary>
		/// <param name="val"></param>
		public void Deflate(int val)
		{
			x += val;
			y += val;
			width -= 2 * val;
			height -= 2 * val;
		}

		/// <summary>
		/// Enlarges this Rectangle by the specified amount.
		/// </summary>
		/// <param name="valX"></param>
		/// <param name="valY"></param>
		public void Inflate(int valX, int valY)
		{
			x -= valX;
			y -= valY;
			width += 2 * valX;
			height += 2 * valY;
		}

		/// <summary>
		/// Reduces this Rectangle by the specified amount.
		/// </summary>
		/// <param name="valX"></param>
		/// <param name="valY"></param>
		public void Deflate(int valX, int valY)
		{
			x += valX;
			y += valY;
			width -= 2 * valX;
			height -= 2 * valY;
		}

		/// <summary>
		/// Enlarges this Rectangle by the specified amount.
		/// </summary>
		/// <param name="val"></param>
		public void Inflate(NppiSize val)
		{
			Inflate(val.width, val.height);
		}

		/// <summary>
		/// Reduces this Rectangle by the specified amount.
		/// </summary>
		/// <param name="val"></param>
		public void Deflate(NppiSize val)
		{
			Deflate(val.width, val.height);
		}

		/// <summary>
		/// Replaces this Rectangle with the intersection of itself and the specified Rectangle.
		/// </summary>
		/// <param name="rect"></param>
		public void Intersect(NppiRect rect)
		{
			int iX = Left;
			if (iX < rect.Left)
			{
				iX = rect.Left;
			}

			int iY = Top;
			if (iY < rect.Top)
			{
				iY = rect.Top;
			}

			int iX2 = Right;
			if (iX2 > rect.Right)
			{
				iX2 = rect.Right;
			}

			int iY2 = Bottom;
			if (iY2 > rect.Bottom)
			{
				iY2 = rect.Bottom;
			}

			int iWidth = iX2 - iX + 1;
			int iHeight = iY2 - iY + 1;
			if (iWidth <= 0 || iHeight <= 0)
			{
				iX = 0;
				iY = 0;
				iWidth = 0;
				iHeight = 0;
			}
			x = iX;
			y = iY;
			width = iWidth;
			height = iHeight;
		}

		/// <summary>
		/// Returns a third Rectangle structure that represents the intersection of two other Rectangle structures.If there is no intersection, an empty Rectangle is returned. 
		/// </summary>
		/// <param name="rectA"></param>
		/// <param name="rectB"></param>
		/// <returns></returns>
		public static NppiRect Intersect(NppiRect rectA, NppiRect rectB)
		{
			int iX = rectA.Left;
			if (iX < rectB.Left)
			{
				iX = rectB.Left;
			}

			int iY = rectA.Top;
			if (iY < rectB.Top)
			{
				iY = rectB.Top;
			}

			int iX2 = rectA.Right;
			if (iX2 > rectB.Right)
			{
				iX2 = rectB.Right;
			}

			int iY2 = rectA.Bottom;
			if (iY2 > rectB.Bottom)
			{
				iY2 = rectB.Bottom;
			}

			int iWidth = iX2 - iX + 1;
			int iHeight = iY2 - iY + 1;
			if (iWidth <= 0 || iHeight <= 0)
			{
				iX = 0;
				iY = 0;
				iWidth = 0;
				iHeight = 0;
			}
			return new NppiRect(iX, iY, iWidth, iHeight);
		}

		/// <summary>
		/// Determines if this rectangle intersects with rect.
		/// </summary>
		/// <param name="rect"></param>
		/// <returns></returns>
		public bool IntersectsWith(NppiRect rect)
		{

			int iX = Left;
			if (iX < rect.Left)
			{
				iX = rect.Left;
			}

			int iY = Top;
			if (iY < rect.Top)
			{
				iY = rect.Top;
			}

			int iX2 = Right;
			if (iX2 > rect.Right)
			{
				iX2 = rect.Right;
			}

			int iY2 = Bottom;
			if (iY2 > rect.Bottom)
			{
				iY2 = rect.Bottom;
			}

			int iWidth = iX2 - iX + 1;
			int iHeight = iY2 - iY + 1;
			if (iWidth <= 0 || iHeight <= 0)
			{
				return false;
			}
			return true;
		}
		#endregion
	}

	/// <summary>
	/// HaarClassifier
	/// </summary>
	[Obsolete("It seems HaarClassifier isn't used at all")]
	public struct HaarClassifier
	{
		/// <summary>
		/// number of classifiers
		/// </summary>
		public int numClassifiers;
		/// <summary>
		/// packed classifier data 40 bytes each
		/// </summary>
		[MarshalAs(UnmanagedType.LPArray)]
		public int[] classifiers;
		/// <summary>
		/// 
		/// </summary>
		public SizeT classifierStep;
		/// <summary>
		/// 
		/// </summary>
		public NppiSize classifierSize;
		/// <summary>
		/// 
		/// </summary>
		[MarshalAs(UnmanagedType.LPArray)]
		public int[] counterDevice;
	}

	/// <summary>
	/// HaarBuffer
	/// </summary>
	[Obsolete("It seems HaarBuffer isn't used at all")]
	public struct HaarBuffer
	{
		/// <summary>
		/// size of the buffer
		/// </summary>
		public int haarBufferSize;
		/// <summary>
		/// buffer
		/// </summary>
		[MarshalAs(UnmanagedType.LPArray)]
		public int[] haarBuffer;
	}

	/// <summary>
	/// graph-cut state structure
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct NppiGraphcutState
	{
		private IntPtr Value;
	}

	/// <summary>
	/// DCT state structure
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct NppiDCTState
	{
		private IntPtr Value;
	}

	/// <summary>
	/// NppiDecodeHuffmanSpec
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct NppiDecodeHuffmanSpec
	{
		private IntPtr Value;
	}

	/// <summary>
	/// NppiEncodeHuffmanSpec
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct NppiEncodeHuffmanSpec
	{
		private IntPtr Value;
	}
	#endregion    
}
