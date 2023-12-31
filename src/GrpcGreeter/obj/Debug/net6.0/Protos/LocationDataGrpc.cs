// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/location_data.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981
#region Designer generated code

using grpc = global::Grpc.Core;

namespace GPRCStreaming {
  public static partial class LocationData
  {
    static readonly string __ServiceName = "location_data.LocationData";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GPRCStreaming.GetLocationsRequest> __Marshaller_location_data_GetLocationsRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GPRCStreaming.GetLocationsRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GPRCStreaming.GetLocationsResponse> __Marshaller_location_data_GetLocationsResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GPRCStreaming.GetLocationsResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GPRCStreaming.GetLocationsRequest, global::GPRCStreaming.GetLocationsResponse> __Method_GetLocations = new grpc::Method<global::GPRCStreaming.GetLocationsRequest, global::GPRCStreaming.GetLocationsResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetLocations",
        __Marshaller_location_data_GetLocationsRequest,
        __Marshaller_location_data_GetLocationsResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GPRCStreaming.GetLocationsRequest, global::GPRCStreaming.GetLocationsResponse> __Method_GetLocations1 = new grpc::Method<global::GPRCStreaming.GetLocationsRequest, global::GPRCStreaming.GetLocationsResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetLocations1",
        __Marshaller_location_data_GetLocationsRequest,
        __Marshaller_location_data_GetLocationsResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::GPRCStreaming.LocationDataReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of LocationData</summary>
    [grpc::BindServiceMethod(typeof(LocationData), "BindService")]
    public abstract partial class LocationDataBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task GetLocations(global::GPRCStreaming.GetLocationsRequest request, grpc::IServerStreamWriter<global::GPRCStreaming.GetLocationsResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GPRCStreaming.GetLocationsResponse> GetLocations1(global::GPRCStreaming.GetLocationsRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(LocationDataBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetLocations, serviceImpl.GetLocations)
          .AddMethod(__Method_GetLocations1, serviceImpl.GetLocations1).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, LocationDataBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetLocations, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::GPRCStreaming.GetLocationsRequest, global::GPRCStreaming.GetLocationsResponse>(serviceImpl.GetLocations));
      serviceBinder.AddMethod(__Method_GetLocations1, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GPRCStreaming.GetLocationsRequest, global::GPRCStreaming.GetLocationsResponse>(serviceImpl.GetLocations1));
    }

  }
}
#endregion
