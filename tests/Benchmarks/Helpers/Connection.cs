﻿namespace System.IO.Pipelines
{
    public class PipeConnection : IPipeConnection
    {
        public PipeConnection(PipeFactory factory)
        {
            Input = factory.Create();
            Output = factory.Create();
        }

        IPipeReader IPipeConnection.Input => Input.Reader;
        IPipeWriter IPipeConnection.Output => Output.Writer;

        public IPipe Input { get; }

        public IPipe Output { get; }

        public void Dispose()
        {
            Input.Reader.Complete();
            Input.Writer.Complete();
            Output.Reader.Complete();
            Output.Writer.Complete();
        }
    }
}