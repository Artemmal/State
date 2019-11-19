using System;

namespace HW24._4
{
    class MusicPlayer
    {
        public IState State { get; set; }
        public MusicPlayer(IState state)
        {
            this.State = state;
        }
        public void PlayOrPause()
        {
            State.PlayOrPause(this);
        }
        public void Stop()
        {
            State.Stop(this);
        }
        public void Next()
        {
            State.Next(this);
        }
        public void Previous()
        {
            State.Previous(this);
        }
    }
    class PlayState : IState
    {
        public void PlayOrPause(MusicPlayer player)
        {
            Console.WriteLine("Pause");
            player.State = new PauseState();
        }
        public void Stop(MusicPlayer player)
        {
            Console.WriteLine("Stop");
            player.State = new StopState();
        }
        public void Next(MusicPlayer player)
        {
            Console.WriteLine("Next song");
        }
        public void Previous(MusicPlayer player)
        {
            Console.WriteLine("Previous song");
        }
    }
    class PauseState : IState
    {
        public void PlayOrPause(MusicPlayer player)
        {
            Console.WriteLine("Play");
            player.State = new PlayState();
        }
        public void Stop(MusicPlayer player)
        {
            Console.WriteLine("Stop");
            player.State = new StopState();
        }
        public void Next(MusicPlayer player)
        {
            Console.WriteLine("Next song");
            player.State = new PlayState();
        }
        public void Previous(MusicPlayer player)
        {
            Console.WriteLine("Previous song");
            player.State = new PlayState();
        }
    }
    class StopState : IState
    {
        public void PlayOrPause(MusicPlayer player)
        {
            Console.WriteLine("Play");
            player.State = new PlayState();
        }
        public void Stop(MusicPlayer player)
        {
            Console.WriteLine("Stop");
        }
        public void Next(MusicPlayer player)
        {
            Console.WriteLine("Next song");
            player.State = new PlayState();
        }
        public void Previous(MusicPlayer player)
        {
            Console.WriteLine("Previous song");
            player.State = new PlayState();

        }
    }
        interface IState
    {
        void PlayOrPause(MusicPlayer musicPlayer);
        void Stop(MusicPlayer musicPlayer);
        void Next(MusicPlayer musicPlayer);
        void Previous(MusicPlayer musicPlayer);
    }

    class Program
    {
        static void Main(string[] args)
        {
            MusicPlayer mp = new MusicPlayer(new StopState());
            mp.PlayOrPause();
            mp.Next();
            mp.PlayOrPause();
            mp.Previous();
            mp.Stop();
        }
    }
}
