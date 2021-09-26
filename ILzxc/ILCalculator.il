.assembly ILzxc
{
.ver 1:0:0:0
}

.class public auto ansi beforefieldinit
  ILzxc.Calculator
    extends [CORE_ASSEMBLY]System.Object
{

  .class nested public sealed auto ansi
    operations
      extends System.Enum
  {

    .field public specialname rtspecialname int32 value__

    .field public static literal valuetype ILzxc.Calculator/operations Plus = int32(0) // 0x00000000

    .field public static literal valuetype ILzxc.Calculator/operations Minus = int32(1) // 0x00000001

    .field public static literal valuetype ILzxc.Calculator/operations Mult = int32(2) // 0x00000002

    .field public static literal valuetype ILzxc.Calculator/operations Divide = int32(3) // 0x00000003

    .field public static literal valuetype ILzxc.Calculator/operations UnknownOperation = int32(4) // 0x00000004
  } // end of class operations

  .field public static class [System.Runtime]System.Exception DivideZero

  .field public static class [System.Runtime]System.Exception WrongOperator

  .method public hidebysig static int32
    Calculate(
      int32 a,
      int32 b,
      valuetype ILzxc.Calculator/operations operation
    ) cil managed
  {
    .custom instance void [System.Runtime]System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute::.ctor()
      = (01 00 00 00 )
    .maxstack 2
    .locals init (
      [0] int32 result
    )

    // [26 13 - 26 28]
    IL_0000: ldc.i4.0
    IL_0001: stloc.0      // result

    IL_0002: ldarg.2      // operation
    IL_0003: switch       (IL_001e, IL_0024, IL_002a, IL_0030, IL_003f)
    IL_001c: br.s         IL_0045

    // [30 21 - 30 36]
    IL_001e: ldarg.0      // a
    IL_001f: ldarg.1      // b
    IL_0020: add
    IL_0021: stloc.0      // result

    // [31 21 - 31 27]
    IL_0022: br.s         IL_0045

    // [33 21 - 33 36]
    IL_0024: ldarg.0      // a
    IL_0025: ldarg.1      // b
    IL_0026: sub
    IL_0027: stloc.0      // result

    // [34 21 - 34 27]
    IL_0028: br.s         IL_0045

    // [36 21 - 36 36]
    IL_002a: ldarg.0      // a
    IL_002b: ldarg.1      // b
    IL_002c: mul
    IL_002d: stloc.0      // result

    // [37 21 - 37 27]
    IL_002e: br.s         IL_0045

    // [39 21 - 39 32]
    IL_0030: ldarg.1      // b
    IL_0031: brtrue.s     IL_0039

    // [41 25 - 41 42]
    IL_0033: ldsfld       class [System.Runtime]System.Exception ILzxc.Calculator::DivideZero
    IL_0038: throw

    // [43 21 - 43 36]
    IL_0039: ldarg.0      // a
    IL_003a: ldarg.1      // b
    IL_003b: div
    IL_003c: stloc.0      // result

    // [44 21 - 44 27]
    IL_003d: br.s         IL_0045

    // [47 21 - 47 41]
    IL_003f: ldsfld       class [System.Runtime]System.Exception ILzxc.Calculator::WrongOperator
    IL_0044: throw

    // [49 13 - 49 27]
    IL_0045: ldloc.0      // result
    IL_0046: ret

  } // end of method Calculator::Calculate

  .method public hidebysig specialname rtspecialname instance void
    .ctor() cil managed
  {
    .maxstack 8

    IL_0000: ldarg.0      // this
    IL_0001: call         instance void [System.Runtime]System.Object::.ctor()
    IL_0006: ret

  } // end of method Calculator::.ctor

  .method private hidebysig static specialname rtspecialname void
    .cctor() cil managed
  {
    .maxstack 8

    // [19 9 - 19 97]
    IL_0000: ldstr        "can not divided by zero"
    IL_0005: newobj       instance void [System.Runtime]System.DivideByZeroException::.ctor(string)
    IL_000a: stsfld       class [System.Runtime]System.Exception ILzxc.Calculator::DivideZero

    // [20 9 - 20 101]
    IL_000f: ldstr        "this operator does not exist"
    IL_0014: newobj       instance void [System.Runtime]System.ArgumentException::.ctor(string)
    IL_0019: stsfld       class [System.Runtime]System.Exception ILzxc.Calculator::WrongOperator
    IL_001e: ret

  } // end of method Calculator::.cctor
} // end of class ILzxc.Calculator
