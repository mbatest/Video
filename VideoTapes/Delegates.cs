using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoTapes
{
    #region Event Arguments and Delegates
    #region Event Arguments
    public class SceneSelectedArgs : EventArgs
    {
        public Scenes scene { get; set; }
    }
    public class MultiSceneSelectedArgs : EventArgs
    {
        public string type { get; set; }
        public List<Scenes> scenes { get; set; }
    }
    public class ShotSelectedArgs : EventArgs
    {
        public Shots Shot { get; set; }
        public List<Shots> Shots { get; set; }

        public string Image { get; set; }

    }
    public class SceneCreatedArgs : EventArgs
    {
        public Scenes scene;
        public SceneCreatedArgs(Scenes s)
        {
            scene = s;
        }
    }
    public class PlaceAddedArgs : EventArgs
    {
        public PlaceAddedArgs()
        {
        }
    }
    public class PersonAddedArgs : EventArgs
    {
        public PersonAddedArgs()
        {
        }
    }
    public class PersonneSelectedArgs : EventArgs
    {
        public Personne Personne { get; set; }
    }
    public class LieuxSelectedArgs : EventArgs
    {
        public Pays Pays { get; set; }
        public Villes Ville { get; set; }
        public Lieux Lieu { get; set; }
    }
    public class DateSelectedArgs : EventArgs
    {
        public DateTime EndDate { get; set; }

        public DateTime BeginDate { get; set; }

    }
    public class KeywordSelectedArgs : EventArgs
    {
        public Keywords KwChoosen  { get; set; }
    }
    public class PlayerArgs: EventArgs
    {
        public bool Pause { get; set; }
        public bool Stop { get; set; }
    }
    #endregion
    #region Delegates
    #region Capture and analysis
    //public delegate void FileRead(object sender, EventArgs e);
    //public delegate void FileHeaderAnalysisCompletedHandler(object sender, FileHeaderAnalysisArgs e);
    //public delegate void FrameReadHandler(object sender, FrameReadArgs e);
    //public delegate void SequenceEventHandler(object sender, SequenceEventArgs e);
    //public delegate void FrameAnalysisEndedHandler(object sender, FrameAnalysisEndedArgs e);
    #endregion
    #region Delegates for interthread operationa
    public delegate void InvalidateControlCallBack(Control ct, Rectangle rect);
    public delegate void RefreshControlCallBack(Control ct);
    public delegate void EnableControlCallBack(ToolStripButton ct, bool en);
    public delegate void EnableMenuItemCallBack(ToolStripMenuItem ct, bool en);
    public delegate void SetTextCallBack(ToolStripLabel ct, string txt);
    public delegate void SetControlTextCallBack(Control ct, string txt);
    public delegate void SetScrollBarCallBack(int max);
    public delegate IntPtr ReturnHandleCallBack(Control ct);
    public delegate Control ReturnControlCallBack(Control ct);
    public delegate void SetControlCallBack(Control ct, Control ct1);
    public delegate void AddPageCallBack(TabControl ct, TabPage p);
    #endregion

    /*  #region Timeline
        public delegate void TrackChangedHandler(object sender, TrackEventArgs e);
        public delegate void MediaItemMovedHandler(object sender, MediaItemArgs e);
        public delegate void MediaItemAddedHandler(object sender, MediaItemArgs e);
        public delegate void MediaItemDeletedHandler(object sender, MediaItemArgs e);
        public delegate void RenderCompletedHandler(object sender, FrameRenderedArgs e);
        public delegate void FileCompletedHandler(object sender, FileCompletedArgs e);
        public delegate void FrameRenderedHandler(object sender, FrameRenderedArgs e);
        #endregion
        #region Thumbviewer
        public delegate void ThumbSelectedHandler(object sender, ThumbSelectedArgs e);
        public delegate void SceneSelectedHandler(object sender, SceneSelectedArgs e);
        public delegate void ShotSelectedHandler(object sender, ShotSelectedArgs e);
        #endregion*/
    public delegate void PlayerHandler(object sender, PlayerArgs e);
    public delegate void ShotSelectedHandler(object sender, ShotSelectedArgs e);
    public delegate void SceneSelectedHandler(object sender, SceneSelectedArgs e);
    public delegate void MultiSceneSelectedHandler(object sender, MultiSceneSelectedArgs e);

    public delegate void SceneCreatedHandler(object sender, SceneCreatedArgs e);
    public delegate void PlaceAddedHandler(object sender, PlaceAddedArgs e);
    public delegate void PersonAddedHandler(object sender, PersonAddedArgs e);
    public delegate void SceneInfoChangedHandler(object sender, SceneSelectedArgs e);
    public delegate void LieuxSelectedHandler(object sender, LieuxSelectedArgs e);
    public delegate void PersonneSelectedHandler(object sender, PersonneSelectedArgs e);
    public delegate void DateSelectedHandler(object sender, DateSelectedArgs e);
    public delegate void KeywordsSelectedHandler(object sender, KeywordSelectedArgs e);
    #endregion
    #endregion

}
