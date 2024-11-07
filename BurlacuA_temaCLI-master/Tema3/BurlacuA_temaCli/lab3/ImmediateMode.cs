using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    internal class ImmediateMode:GameWindow
    {
        
        public ImmediateMode():base(800,600)///adreseaza fereastrainvocand constructorul din clasa parinte
        {
            VSync = VSyncMode.On;//daca nu il punem avem intreruperi in imagini
            //protected-sunt declarate in clasa parinte,se executa partial in clasa parinte si i clasa copil


        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);//il ia din clasa parinte
            //daca nu punem base nu deseneaza fereastra
            GL.ClearColor(Color.Green);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);


            
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);


        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
        }


    }
}
