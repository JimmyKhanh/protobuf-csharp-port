// Generated by ProtoGen, Version=2.3.0.277, Culture=neutral, PublicKeyToken=8fd7408b07f8d2cd.  DO NOT EDIT!

using pb = global::Google.ProtocolBuffers;
using pbc = global::Google.ProtocolBuffers.Collections;
using pbd = global::Google.ProtocolBuffers.Descriptors;
using scg = global::System.Collections.Generic;
namespace Google.ProtocolBuffers.TestProtos {
  
  public static partial class UnitTestEmptyProtoFile {
  
    #region Extension registration
    public static void RegisterAllExtensions(pb::ExtensionRegistry registry) {
    }
    #endregion
    #region Static variables
    #endregion
    #region Descriptor
    public static pbd::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbd::FileDescriptor descriptor;
    
    static UnitTestEmptyProtoFile() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          "CiRnb29nbGUvcHJvdG9idWYvdW5pdHRlc3RfZW1wdHkucHJvdG8aJGdvb2ds" + 
          "ZS9wcm90b2J1Zi9jc2hhcnBfb3B0aW9ucy5wcm90b0I+wj47CiFHb29nbGUu" + 
          "UHJvdG9jb2xCdWZmZXJzLlRlc3RQcm90b3MSFlVuaXRUZXN0RW1wdHlQcm90" + 
          "b0ZpbGU=");
      pbd::FileDescriptor.InternalDescriptorAssigner assigner = delegate(pbd::FileDescriptor root) {
        descriptor = root;
        pb::ExtensionRegistry registry = pb::ExtensionRegistry.CreateInstance();
        RegisterAllExtensions(registry);
        global::Google.ProtocolBuffers.DescriptorProtos.CSharpOptions.RegisterAllExtensions(registry);
        return registry;
      };
      pbd::FileDescriptor.InternalBuildGeneratedFileFrom(descriptorData,
          new pbd::FileDescriptor[] {
          global::Google.ProtocolBuffers.DescriptorProtos.CSharpOptions.Descriptor, 
          }, assigner);
    }
    #endregion
    
  }
}
