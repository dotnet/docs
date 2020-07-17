namespace InterfaceDemo
{
public ref class MyMediaPlayer sealed : public IMediaPlayer
    {
    public:
        //IMediaPlayer
        virtual event OnStateChanged^ StateChanged;
        virtual property Platform::String^ CurrentTitle;
        virtual property PlayState CurrentState;
        virtual void Play()
        {
                             // …
            auto args = ref new MediaPlayerEventArgs(); 
            args->newState = PlayState::Playing;
            args->oldState = PlayState::Stopped;
            StateChanged(this, args);
        }
        virtual void Pause(){/*...*/}
        virtual void Stop(){/*...*/}
        virtual void Forward(float speed){/*...*/}
        virtual void Back(float speed){/*...*/}
    private:
        //...
    };
}