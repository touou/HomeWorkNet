// Type: ILzxc.Parser 
// Assembly: ILzxc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 416F4C87-8ED5-481A-9941-F9060FFDEF6D
// Location: D:\git\HomeWorkNet\ILzxc\ILzxc\bin\Release\net5.0\ILzxc.dll
// Sequence point data from D:\git\HomeWorkNet\ILzxc\ILzxc\bin\Release\net5.0\ILzxc.pdb

.class public auto ansi beforefieldinit
  ILzxc.Parser
    extends [CORE_ASSEMBLY]System.Object
   
{
  .method public hidebysig static bool
    IsInt(
      string num1,
      [out] int32& num11
    ) cil managed
  {
    .maxstack 8

    // [10 13 - 10 47]
    IL_0000: ldarg.0      // num1
    IL_0001: ldarg.1      // num11
    IL_0002: call         bool [System.Runtime]System.Int32::TryParse(string, int32&)
    IL_0007: brfalse.s    IL_000b

    // [11 17 - 11 29]
    IL_0009: ldc.i4.1
    IL_000a: ret

    // [14 17 - 14 30]
    IL_000b: ldc.i4.0
    IL_000c: ret

  } // end of method Parser::IsInt

  .method public hidebysig static valuetype ILzxc.Calculator/operations
    OperationDetector(
      string arg
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] valuetype ILzxc.Calculator/operations operation
    )

    IL_0000: ldarg.0      // arg
    IL_0001: ldstr        "+"
    IL_0006: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_000b: brtrue.s     IL_0036
    IL_000d: ldarg.0      // arg
    IL_000e: ldstr        "-"
    IL_0013: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_0018: brtrue.s     IL_003a
    IL_001a: ldarg.0      // arg
    IL_001b: ldstr        "*"
    IL_0020: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_0025: brtrue.s     IL_003e
    IL_0027: ldarg.0      // arg
    IL_0028: ldstr        "/"
    IL_002d: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_0032: brtrue.s     IL_0042
    IL_0034: br.s         IL_0046

    // [24 21 - 24 60]
    IL_0036: ldc.i4.0
    IL_0037: stloc.0      // operation

    // [25 21 - 25 27]
    IL_0038: br.s         IL_0048

    // [27 21 - 27 61]
    IL_003a: ldc.i4.1
    IL_003b: stloc.0      // operation

    // [28 21 - 28 27]
    IL_003c: br.s         IL_0048

    // [30 21 - 30 60]
    IL_003e: ldc.i4.2
    IL_003f: stloc.0      // operation

    // [31 21 - 31 27]
    IL_0040: br.s         IL_0048

    // [33 21 - 33 62]
    IL_0042: ldc.i4.3
    IL_0043: stloc.0      // operation

    // [34 21 - 34 27]
    IL_0044: br.s         IL_0048

    // [36 21 - 36 72]
    IL_0046: ldc.i4.4
    IL_0047: stloc.0      // operation

    // [39 13 - 39 30]
    IL_0048: ldloc.0      // operation
    IL_0049: ret

  } // end of method Parser::OperationDetector

  .method public hidebysig specialname rtspecialname instance void
    .ctor() cil managed
  {
    .maxstack 8

    IL_0000: ldarg.0      // this
    IL_0001: call         instance void [System.Runtime]System.Object::.ctor()
    IL_0006: ret

  } // end of method Parser::.ctor
} // end of class ILzxc.Parser
