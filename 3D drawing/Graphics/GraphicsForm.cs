﻿using System.Windows.Forms;
using System.Threading;
namespace Graphics
{
    public partial class GraphicsForm : Form
    {
        Renderer renderer = new Renderer();
        Thread MainLoopThread;
        public GraphicsForm()
        {
            InitializeComponent();
            simpleOpenGlControl1.InitializeContexts();
            initialize();
            MainLoopThread = new Thread(MainLoop);
            MainLoopThread.Start();

        }
        void initialize()
        {
            renderer.Initialize();   
        }
        
        void MainLoop()
        {
            while (true)
            {
                renderer.Update();
                renderer.Draw();
                simpleOpenGlControl1.Refresh();
            }
        }
        private void GraphicsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            renderer.CleanUp();
            MainLoopThread.Abort();
        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            renderer.Draw();
        }

    }
}
