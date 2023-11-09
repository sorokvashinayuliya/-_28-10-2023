using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ДЗ_28_10_2023
{
    internal class Song
    {
        public string songName;
        public string songAuthor;
        public string previousSong;
        public string SongName
        {
            get
            {
                return songName;
            }
        }
        public string SongAuthor
        {
            get
            {
                return songAuthor;
            }
        }
        public string PreviousSong
        {
            get
            {
                return previousSong;
            }
        }
        public string Conclusions
        {
            get
            {
                return songName + " " + songAuthor;
            }
        }
        public override bool Equals(object transmittedSong)
        {
            Song song = transmittedSong as Song;
            if ((song!=null) && (song.SongName==songName)&& (song.SongAuthor == songAuthor))
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public Song(string songName, string songAuthor, string previousSong)
        {
            this.songName = songName;
            this.songAuthor = songAuthor;
            this.previousSong = previousSong;
        }
        public Song(string songName, string songAuthor)
        {
            this.songName = songName;
            this.songAuthor = songAuthor;
            previousSong = null;
        }

    }
}
