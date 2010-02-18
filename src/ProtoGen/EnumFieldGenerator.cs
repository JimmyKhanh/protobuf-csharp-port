#region Copyright notice and license
// Protocol Buffers - Google's data interchange format
// Copyright 2008 Google Inc.  All rights reserved.
// http://github.com/jskeet/dotnet-protobufs/
// Original C++/Java/Python code:
// http://code.google.com/p/protobuf/
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are
// met:
//
//     * Redistributions of source code must retain the above copyright
// notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above
// copyright notice, this list of conditions and the following disclaimer
// in the documentation and/or other materials provided with the
// distribution.
//     * Neither the name of Google Inc. nor the names of its
// contributors may be used to endorse or promote products derived from
// this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
// OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
#endregion

using Google.ProtocolBuffers.Descriptors;

namespace Google.ProtocolBuffers.ProtoGen {
  internal class EnumFieldGenerator : FieldGeneratorBase, IFieldSourceGenerator {
    internal EnumFieldGenerator(FieldDescriptor descriptor)
        : base(descriptor) {
    }

    public void GenerateMembers(TextGenerator writer) {
      writer.WriteLine("private bool has{0};", PropertyName);
      writer.WriteLine("private {0} {1}_ = {2};", TypeName, Name, DefaultValue);
      writer.WriteLine("public bool Has{0} {{", PropertyName);
      writer.WriteLine("  get {{ return has{0}; }}", PropertyName);
      writer.WriteLine("}");
      AddClsComplianceCheck(writer);
      writer.WriteLine("public {0} {1} {{", TypeName, PropertyName);
      writer.WriteLine("  get {{ return {0}_; }}", Name);
      writer.WriteLine("}");
    }

    public void GenerateBuilderMembers(TextGenerator writer) {
      writer.WriteLine("public bool Has{0} {{", PropertyName);
      writer.WriteLine(" get {{ return result.Has{0}; }}", PropertyName);
      writer.WriteLine("}");
      AddClsComplianceCheck(writer);
      writer.WriteLine("public {0} {1} {{", TypeName, PropertyName);
      writer.WriteLine("  get {{ return result.{0}; }}", PropertyName);
      writer.WriteLine("  set {{ Set{0}(value); }}", PropertyName);
      writer.WriteLine("}");
      AddClsComplianceCheck(writer);
      writer.WriteLine("public Builder Set{0}({1} value) {{", PropertyName, TypeName);
      writer.WriteLine("  result.has{0} = true;", PropertyName);
      writer.WriteLine("  result.{0}_ = value;", Name);
      writer.WriteLine("  return this;");
      writer.WriteLine("}");
      writer.WriteLine("public Builder Clear{0}() {{", PropertyName);
      writer.WriteLine("  result.has{0} = false;", PropertyName);
      writer.WriteLine("  result.{0}_ = {1};", Name, DefaultValue);
      writer.WriteLine("  return this;");
      writer.WriteLine("}");
    }

    public void GenerateMergingCode(TextGenerator writer) {
      writer.WriteLine("if (other.Has{0}) {{", PropertyName);
      writer.WriteLine("  {0} = other.{0};", PropertyName);
      writer.WriteLine("}");
    }

    public void GenerateBuildingCode(TextGenerator writer) {
      // Nothing to do here for enum types
    }

    public void GenerateParsingCode(TextGenerator writer) {
      // TODO(jonskeet): Make a more efficient way of doing this
      writer.WriteLine("int rawValue = input.ReadEnum();");
      writer.WriteLine("if (!global::System.Enum.IsDefined(typeof({0}), rawValue)) {{", TypeName);
      writer.WriteLine("  if (unknownFields == null) {"); // First unknown field - create builder now
      writer.WriteLine("    unknownFields = pb::UnknownFieldSet.CreateBuilder(this.UnknownFields);");
      writer.WriteLine("  }");
      writer.WriteLine("  unknownFields.MergeVarintField({0}, (ulong) rawValue);", Number);
      writer.WriteLine("} else {");
      writer.WriteLine("  {0} = ({1}) rawValue;", PropertyName, TypeName);
      writer.WriteLine("}");
    }

    public void GenerateSerializationCode(TextGenerator writer) {
      writer.WriteLine("if (Has{0}) {{", PropertyName);
      writer.WriteLine("  output.WriteEnum({0}, (int) {1});", Number, PropertyName);
      writer.WriteLine("}");
    }

    public void GenerateSerializedSizeCode(TextGenerator writer) {
      writer.WriteLine("if (Has{0}) {{", PropertyName);
      writer.WriteLine("  size += pb::CodedOutputStream.ComputeEnumSize({0}, (int) {1});", Number, PropertyName);
      writer.WriteLine("}");    
    }
  }
}
