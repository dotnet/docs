    public ref class ErrorFilter : TraceFilter
    {
    public:
        virtual bool ShouldTrace(TraceEventCache^ cache, String^ source,
            TraceEventType eventType, int id, String^ formatOrMessage,
            array<Object^>^ args, Object^ data, array<Object^>^ dataArray) override
        {
            return eventType == TraceEventType::Error;
        }
    };