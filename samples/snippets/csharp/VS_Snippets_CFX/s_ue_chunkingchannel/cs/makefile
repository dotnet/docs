all: ChannelHelpers.dll ChunkingChannel.dll

ChannelHelpers.dll: SynchronizedQueue.cs TimeoutHelper.cs
 csc /t:library /out:ChannelHelpers.dll SynchronizedQueue.cs TimeoutHelper.cs /r:System.Runtime.Serialization.dll /r:System.ServiceModel.dll
 
ChunkingChannel.dll:  ChunkingBehavior.cs ChunkingBindingElement.cs ChunkingBodyWriter.cs ChunkingChannelFactory.cs ChunkingChannelListener.cs ChunkingDuplexSessionChannel.cs ChunkingMessage.cs ChunkingReader.cs ChunkingUtils.cs ChunkingWriter.cs
 csc /t:library ChunkingBehavior.cs ChunkingBindingElement.cs ChunkingBodyWriter.cs ChunkingChannelFactory.cs ChunkingChannelListener.cs ChunkingDuplexSessionChannel.cs ChunkingMessage.cs ChunkingReader.cs ChunkingUtils.cs ChunkingWriter.cs /r:System.ServiceModel.dll /r:System.Runtime.Serialization.dll /r:ChannelHelpers.dll 
