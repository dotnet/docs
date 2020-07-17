#pragma once

//<snippet01>
namespace InterfacesTest
{
    public enum class PlayState {Playing, Paused, Stopped, Forward, Reverse};

    public ref struct MediaPlayerEventArgs sealed
    {
        property PlayState oldState;
        property PlayState newState;
    };

    public delegate void OnStateChanged(Platform::Object^ sender, MediaPlayerEventArgs^ a);
    public interface class IMediaPlayer // or public interface struct IMediaPlayer 
    {
        event OnStateChanged^ StateChanged;
        property Platform::String^ CurrentTitle;
        property PlayState CurrentState;
        void Play();
        void Pause();
        void Stop();
        void Back(float speed);
        void Forward(float speed);
    };
}
//</snippet01>

namespace InterfacesTest
{
    //<snippet02>
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
    //</snippet02>

    //<snippet03>
    public interface struct A { void DoSomething(); };
    public interface struct B : A { void DoSomethingMore();};

    public ref struct C sealed : B
    {
        virtual void DoSomething(){}
        virtual void DoSomethingMore(){}
    };


    //</snippet03>


    ref class Test
    {
    public:
        //<snippet04>
        //Alternate implementation in MediaPlayer class of IMediaPlayer::CurrentTitle
        virtual property Platform::String^ CurrentTitle
        {
            Platform::String^ get() {return "Now playing: " + _title;}
            void set(Platform::String^ t) {_title = t; }
        }
        //</snippet04>
    private:
        Platform::String^ _title;
    };


    namespace embedded
    {
        //<snippet05>
        public interface class IMediaPlayer
        {
            //...
            property Platform::String^ CurrentTitle
            {
                Platform::String^ get();           
            }
        };

        public ref class MyMediaPlayer3 sealed : public IMediaPlayer
        {
        public:
            //...
            virtual property Platform::String^ CurrentTitle
            {
                Platform::String^ get() {return "Now playing: " + _title;}
            }
        private:
            Platform::String^ _title;
        };
        //</snippet05>
    }
    //<snippet06>
    public interface class IArtist
    {     
        Platform::String^ Draw();
    };

    public interface class ICowboy
    {
        Platform::String^ Draw();
    };

    public ref class MyClass sealed : public IArtist, ICowboy
    {
    public:     
        MyClass(){}     
        virtual  Platform::String^ ArtistDraw() = IArtist::Draw {return L"Artist";}
        virtual  Platform::String^ CowboyDraw() = ICowboy::Draw {return L"Cowboy";}
    };
    //</snippet06>

    //<snippet07>
    public ref class MediaFile sealed {};

    generic <typename T>
    private interface class  IFileCollection
    {
        property Windows::Foundation::Collections::IVector<T>^ Files;
        Platform::String^  GetFileInfoAsString(T file);
    };

    private ref class MediaFileCollection : IFileCollection<MediaFile^>
    {
    public:
        virtual property Windows::Foundation::Collections::IVector<MediaFile^>^ Files;
        virtual Platform::String^  GetFileInfoAsString(MediaFile^ file){return "";}
    };

    public interface class ILibraryClient
    {
        bool FindTitle(Platform::String^ title);       
        //...
    };

    public ref class MediaPlayer sealed : public IMediaPlayer, public ILibraryClient
    {
    public:
        //IMediaPlayer
        virtual event OnStateChanged^ StateChanged;
        virtual property Platform::String^ CurrentTitle;
        virtual property PlayState CurrentState;
        virtual void Play()
        {
            auto args = ref new MediaPlayerEventArgs(); 
            args->newState = PlayState::Playing;
            args->oldState = PlayState::Stopped;
            StateChanged(this, args);
        }
        virtual void Pause(){/*...*/}
        virtual void Stop(){/*...*/}
        virtual void Forward(float speed){/*...*/}
        virtual void Back(float speed){/*...*/}

        //ILibraryClient
        virtual bool FindTitle(Platform::String^ title){/*...*/ return true;}

    private:
        MediaFileCollection^ fileCollection;

    };
    //</snippet07>



    namespace Example3
    {
        public interface class IMediaPlayer
        {
            //...
            property Platform::String^ CurrentTitle
            {
                Platform::String^ get();           
            }
        };

        public ref class MyMediaPlayer3 sealed : public IMediaPlayer
        {
        public:
            //...
            virtual property Platform::String^ CurrentTitle
            {
                Platform::String^ get() {return "Now playing: " + _title;}
            }
        private:
            Platform::String^ _title;
        };

    }





    //Generic Interface t-> test
    generic <typename T>
    interface class TestIFace
    {
        property T data;
    };

    template <typename T>
    ref class TestClass : public TestIFace<T>
    {
    public:
        virtual property T data;
        bool IsNull()
        {
            // No compile error!!!!
            return data->Foo(nullptr);
        }
    };


}