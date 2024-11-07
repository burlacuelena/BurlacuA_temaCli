using System;
using System.Drawing;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace OpenTK_console_sample01
{
    class SimpleWindow : GameWindow
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TextFile1.txt");

        // Variabile pentru poziția triunghiului
        Vector2[] triangleVertices = new Vector2[3];
        float[,] triangleColors = new float[3, 4]; // RGB + Alpha pentru fiecare vertex
        float rotationAngle = 0.0f;

        public SimpleWindow() : base(800, 600)
        {
            KeyDown += Keyboard_KeyDown;
            MouseMove += Mouse_Move;
            LoadTriangleVertices(path);
        }

        // Funcție pentru a încărca coordonatele triunghiului dintr-un fișier text
        void LoadTriangleVertices(string path)
        {
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                for (int i = 0; i < 3 && i < lines.Length; i++)
                {
                    var coords = lines[i].Split(' ');
                    triangleVertices[i] = new Vector2(float.Parse(coords[0]), float.Parse(coords[1]));

                    // Setăm culorile inițiale pentru fiecare vertex
                    triangleColors[i, 0] = 1.0f; // Roșu
                    triangleColors[i, 1] = 1.0f; // Verde
                    triangleColors[i, 2] = 1.0f; // Albastru
                    triangleColors[i, 3] = 1.0f; // Alpha

                    // Afișăm coordonatele și culorile în consolă
                    Console.WriteLine($"Vertex {i}: ({triangleVertices[i].X}, {triangleVertices[i].Y}) - RGB({triangleColors[i, 0]}, {triangleColors[i, 1]}, {triangleColors[i, 2]}, {triangleColors[i, 3]})");
                }
            }
            else
            {
                Console.WriteLine("Fișierul cu coordonate nu a fost găsit.");
                // Setăm coordonatele la valori implicite
                triangleVertices[0] = new Vector2(-1.0f, 1.0f);
                triangleVertices[1] = new Vector2(0.0f, -1.0f);
                triangleVertices[2] = new Vector2(1.0f, 1.0f);
            }
        }

        // Controlul prin tastatură: modifică culoarea și transparența
        void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Exit();

            if (e.Key == Key.F11)
                this.WindowState = this.WindowState == WindowState.Fullscreen ? WindowState.Normal : WindowState.Fullscreen;

            // Modificăm culoarea pentru fiecare vertex
            if (e.Key == Key.R) SetTriangleColor(0, 0.1f); // crește roșu pentru vertex 0
            if (e.Key == Key.G) SetTriangleColor(1, 0.1f); // crește verde pentru vertex 1
            if (e.Key == Key.B) SetTriangleColor(2, 0.1f); // crește albastru pentru vertex 2

            if (e.Key == Key.T) SetTriangleColor(0, -0.1f); // reduce roșu pentru vertex 0
            if (e.Key == Key.Y) SetTriangleColor(1, -0.1f); // reduce verde pentru vertex 1
            if (e.Key == Key.U) SetTriangleColor(2, -0.1f); // reduce albastru pentru vertex 2


            // Afișăm culorile în consolă
            DisplayColors();
        }

        void SetTriangleColor(int vertexIndex, float change)
        {
            for (int i = 0; i < 3; i++)
            {
                triangleColors[i, vertexIndex] = Clamp(triangleColors[i, vertexIndex] + change, 0.0f, 1.0f);
            }
        }

        // Implementare funcție Clamp
        public static float Clamp(float value, float min, float max)
        {
            return Math.Max(min, Math.Min(max, value));
        }

        void DisplayColors()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Vertex {i} Color: RGB({triangleColors[i, 0]}, {triangleColors[i, 1]}, {triangleColors[i, 2]}, {triangleColors[i, 3]})");
            }
        }

        // Controlul rotației camerei prin mișcarea mouse-ului
        void Mouse_Move(object sender, MouseMoveEventArgs e)
        {
            rotationAngle = (e.X - (Width / 2.0f)) * 0.1f;
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.MidnightBlue);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc((BlendingFactor)BlendingFactorSrc.SrcAlpha, (BlendingFactor)BlendingFactorDest.OneMinusSrcAlpha);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-5.0, 5.0, -5.0, 5.0, -1.0, 1.0);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            // Aplicăm rotația camerei
            GL.Rotate(rotationAngle, 0.0f, 1.0f, 0.0f);

            // Randare triunghi
            GL.Begin(PrimitiveType.Triangles);
            for (int i = 0; i < 3; i++)
            {
                GL.Color4(triangleColors[i, 0], triangleColors[i, 1], triangleColors[i, 2], triangleColors[i, 3]);
                GL.Vertex2(triangleVertices[i].X, triangleVertices[i].Y);
            }
            GL.End();

            SwapBuffers();
        }

        [STAThread]
        static void Main(string[] args)
        {
            using (SimpleWindow example = new SimpleWindow())
            {
                example.Run(30.0, 0.0);
            }
        }
    }
}
