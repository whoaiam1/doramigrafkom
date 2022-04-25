using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

namespace Pert1
{
    static class Constant
    {
        public const string PATH = "../../../Shaders/";
    }
    internal class Window : GameWindow
    {
        //Asset2d[] _object = new Asset2d[10];
        //float[] _vertices =
        //{
        //    //x     //y   //z
        //    -0.5f, -0.5f, 0.0f, //vertices 1
        //    0.5f, -0.5f, 0.0f, //vertices 2
        //    0.0f, 0.5f, 0.0f //vertices 3
        //};
        //float[] _vertices =
        //{
        //    //x     //y   //z
        //    -0.75f, 0.0f, 0.0f, //vertices 1
        //    -0.25f, 0.0f, 0.0f, //vertices 2
        //    -0.5f, 0.5f, 0.0f //vertices 3
        //};

        //float[] _vertices =
        //        {
        //            //x     //y   //z
        //            -0.5f, -0.5f, 0.0f, 1.0f, 0.0f, 0.0f, //vertices 1
        //            0.5f, -0.5f, 0.0f, 0.0f, 1.0f, 0.0f,//vertices 2
        //            0.0f, 0.5f, 0.0f, 0.0f, 0.0f, 1.0f, //vertices 3
        //        };

        //float[] _vertices =
        //{
        //    0.5f, 0.5f, 0.0f, 
        //    0.5f, -0.5f, 0.0f,
        //    -0.5f, -0.5f, 0.0f,
        //    -0.5f, 0.5f, 0.0f
        //};
        //uint[] _indices =
        //{
        //    0,1,3,
        //    1,2,3
        //};
        //int _vertexBufferObject;
        //int _vertexArrayObject;
        //int _elementBufferObject;
        //Shader _shader;
        Asset3d[] _object3d = new Asset3d[20];
        Asset3d bodyDorami;
        Asset3d main_headDorami;
        Asset3d cone;
        Asset3d right_handDorami;
        Asset3d left_handDorami;
        Asset3d right_footDorami;
        Asset3d left_footDorami;
        Asset3d cam = new Asset3d();
        Camera _camera;
        bool _firstMove = true;
        Vector2 _lastPos;
        Vector3 _objectPos = new Vector3(0.0f, 0.0f, 0.0f);
        float _rotationSpeed = 1;

        Asset3d dorami = new Asset3d();

        float degree = 0;
        double _time = 0;
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {

        }

        public void makebodyDorami()
        {
            //Ganti Background
            GL.ClearColor(0f, 0f, 0f, 1.0f);
            _object3d[0] = new Asset3d();
            bodyDorami = new Asset3d();

            //Badan
            _object3d[0] = new Asset3d();
            _object3d[0].createEllipsoid2(0.5f, 0.5f, 0.5f, 0.0f, 0.0f, 0.0f, 300, 100);
            _object3d[0].setColor(new Vector3(255, 228, 59));
            bodyDorami.addChildClass(_object3d[0]);

            //Outline Kantong
            _object3d[3] = new Asset3d();
            _object3d[3].createHalfBall(0.3f, 0.3f, 0.03f, 0.0f, -0.15f, 0.475f, 800, 2000);
            _object3d[3].rotate(_object3d[0]._center, _object3d[0]._euler[2], 180);
            _object3d[3].rotate(_object3d[0]._center, _object3d[0]._euler[0], 10);
            _object3d[3].setColor(new Vector3(0, 0, 0));
            bodyDorami.addChildClass(_object3d[3]);

            //kantong
            _object3d[4] = new Asset3d();
            _object3d[4].createHalfBall(0.28f, 0.28f, 0.0f, 0.0f, -0.2f, 0.5f, 800, 2000);
            _object3d[4].rotate(_object3d[0]._center, _object3d[0]._euler[2], 180);
            _object3d[4].rotate(_object3d[0]._center, _object3d[0]._euler[0], 15);
            _object3d[4].setColor(new Vector3(255, 255, 255));
            bodyDorami.addChildClass(_object3d[4]);

            //kalung lonceng
            _object3d[5] = new Asset3d();
            _object3d[5].createEllipsoid2(0.5f, 0.08f, 0.5f, 0.0f, 0.29f, 0.0f, 300, 100);
            _object3d[5].setColor(new Vector3(2, 160, 231));
            bodyDorami.addChildClass(_object3d[5]);


            //bg lonceng
            _object3d[6] = new Asset3d();
            _object3d[6].createEllipsoid2(0.11f, 0.01f, 0.11f, 0.0f, 0.19f, 0.55f, 300, 100);
            _object3d[6].setColor(new Vector3(255, 165, 0));
            bodyDorami.addChildClass(_object3d[6]);

            //Lonceng
            _object3d[7] = new Asset3d();
            _object3d[7].createEllipsoid2(0.1f, 0.1f, 0.1f, 0.0f, 0.19f, 0.55f, 300, 100);
            _object3d[7].setColor(new Vector3(255, 255, 0));
            bodyDorami.addChildClass(_object3d[7]);
        }

        public void makeHeadDorami()
        {
            main_headDorami = new Asset3d();
            //main_headDorami.createElipseoid(0.5f, 0.45f, 0.4f, 0.5f, 0.5f, 0.5f);
            main_headDorami.createEllipsoid2(0.5f, 0.45f, 0.5f, 0.0f, 0.0f, 0.0f, 300, 100);
            main_headDorami.setColor(new Vector3(253, 229, 63));

            Asset3d eyes = new Asset3d();

            eyes.createEllipsoid2(0.1f, 0.12f, 0.1f, -0.15f, 0.02f, 0.43f, 300, 100);
            eyes.setColor(new Vector3(255.0f, 255.0f, 255.0f));
            main_headDorami.addChildClass(eyes);

            eyes = new Asset3d();
            eyes.createEllipsoid2(0.1f, 0.12f, 0.1f, 0.15f, 0.02f, 0.43f, 300, 100);
            eyes.setColor(new Vector3(255.0f, 255.0f, 255.0f));
            main_headDorami.addChildClass(eyes);

            eyes = new Asset3d();
            eyes.createEllipsoid2(0.1f / 3f, 0.15f / 3f, 0.05f / 3f, 0.15f, 0f, 0.53f, 300, 100);
            eyes.setColor(new Vector3(0.0f, 0.0f, 0.0f));
            main_headDorami.addChildClass(eyes);


            eyes = new Asset3d();
            eyes.createEllipsoid2(0.1f / 3f, 0.15f / 3f, 0.05f / 3f, -0.15f, 0f, 0.53f, 300, 100);
            eyes.setColor(new Vector3(0.0f, 0.0f, 0.0f));
            main_headDorami.addChildClass(eyes);
            Asset3d cheek = new Asset3d();
            Asset3d smile = new Asset3d();
            Asset3d nose = new Asset3d();
            cheek.createEllipsoid2(0.35f, 0.3f, 0.1f, 0.0f, -0.05f, 0.42f, 300, 100);
            cheek.setColor(new Vector3(240f, 240f, 240f));

            nose.createEllipsoid2(0.055f, 0.035f, 0.055f, 0.0f, -0.1f, 0.48f, 300, 100);
            nose.setColor(new Vector3(251, 207, 208));

            smile.createHalfBall(0.1f, 0.12f, 0f, 0.0f, 0.01f, 0.545f, 800, 2000);
            smile.setColor(new Vector3(255f, 0f, 0f));
            smile.rotate(main_headDorami._center, main_headDorami._euler[2], 180);
            smile.rotate(main_headDorami._center, main_headDorami._euler[0], 15);
            main_headDorami.addChildClass(smile);
            main_headDorami.addChildClass(cheek);
            main_headDorami.addChildClass(nose);
            Asset3d ears;
            //right ear
            ears = new Asset3d();
            ears.EllipPara(0.021f, 0.021f, 0.004f, -0.07f, 0f, -0.76f);
            ears.rotate(main_headDorami._center, ears._euler[0], 90);
            ears.rotate(main_headDorami._center, ears._euler[1], 15);
            ears.setColor(new Vector3(225, 0, 42));
            main_headDorami.addChildClass(ears);
            //left ear
            ears = new Asset3d();
            ears.EllipPara(0.021f, 0.021f, 0.004f, 0.07f, 0f, -0.76f);
            ears.rotate(main_headDorami._center, ears._euler[0], 90);
            ears.rotate(main_headDorami._center, ears._euler[1], -15);
            ears.setColor(new Vector3(225, 0, 42));
            main_headDorami.addChildClass(ears);
        }

        public void makeHandDorami()
        {
            //right hand
            right_handDorami = new Asset3d();
            right_handDorami.createEllipsoid2(0.12f, 0.12f, 0.12f, 0.55f, 0.3f, 0.0f, 300, 100);
            right_handDorami.setColor(new Vector3(211, 211, 211));
            //right arm
            Asset3d arm = new Asset3d();
            arm.EllipPara(0.011f, 0.011f, 0.004f, 0.45f, 0f, 0f);
            arm.setColor(new Vector3(255, 200, 59));
            arm.rotate(right_handDorami._center, arm._euler[0], 270);
            arm.rotate(right_handDorami._center, arm._euler[1], 15);
            right_handDorami.addChildClass(arm);

            //left hand
            left_handDorami = new Asset3d();
            left_handDorami.createEllipsoid2(0.12f, 0.12f, 0.12f, -0.55f, -0.3f, 0.0f, 300, 100);
            left_handDorami.setColor(new Vector3(211, 211, 211));
            //left arm
            arm = new Asset3d();
            arm.EllipPara(0.011f, 0.011f, 0.004f, -0.45f, 0f, 0f);
            arm.setColor(new Vector3(255, 200, 59));
            arm.rotate(left_handDorami._center, arm._euler[0], 90);
            arm.rotate(left_handDorami._center, arm._euler[1], -15);
            left_handDorami.addChildClass(arm);
        }

        public void makeFootDorami()
        {
            //right foot
            right_footDorami = new Asset3d();
            right_footDorami.createEllipsoid2(0.2f, 0.1f, 0.2f, 0.2f, -0.75f, 0.0f, 300, 100);
            right_footDorami.setColor(new Vector3(211, 211, 211));
            //right leg
            Asset3d leg = new Asset3d();
            leg.createHalfBall(0.15f, 0.4f, 0.15f, 0.2f, -0.7f, 0.0f, 800, 2000);
            leg.setColor(new Vector3(255, 200, 59));
            right_footDorami.addChildClass(leg);

            //left foot
            left_footDorami = new Asset3d();
            left_footDorami.createEllipsoid2(0.2f, 0.1f, 0.2f, -0.2f, -0.75f, 0.0f, 300, 100);
            left_footDorami.setColor(new Vector3(211, 211, 211));
            //left leg
            leg = new Asset3d();
            leg.createHalfBall(0.15f, 0.4f, 0.15f, -0.2f, -0.7f, 0.0f, 800, 2000);
            leg.setColor(new Vector3(255, 200, 59));
            left_footDorami.addChildClass(leg);
        }

        public void makeDorami()
        {
            makeHeadDorami();
            makebodyDorami();
            makeHandDorami();
            makeFootDorami();

            main_headDorami.translateObject(0.5f);
            bodyDorami.translateObject(-0.15f);
            right_handDorami.translateObject(0.15f);

            dorami.addChildClass(main_headDorami);
            dorami.addChildClass(bodyDorami);
            dorami.addChildClass(right_handDorami);
            dorami.addChildClass(left_handDorami);
            dorami.addChildClass(right_footDorami);
            dorami.addChildClass(left_footDorami);

            dorami.translateAll(-2, 0, 0);
        }

        bool plus_dorami = true;
        float rotate_dorami = 0;
        float rotdeg_dorami = 1;
        float totalRot_dorami = 20;

        public void animateDorami()
        {
            if (rotate_dorami >= 0 && rotate_dorami < totalRot_dorami)
            {
                plus_dorami = true;
            }
            else
            {
                //first checking after rotate_dorami is equal to total rotation (totalRot)
                if (plus_dorami)
                {
                    rotate_dorami = -1;
                }

                if (rotate_dorami > (-1 * totalRot_dorami - 1))
                {
                    plus_dorami = false;
                }
                else
                {
                    rotate_dorami = 0;
                    plus_dorami = true;
                }
            }
            if (plus_dorami)
            {
                dorami.Child[2].rotate(dorami._center, dorami.Child[2]._euler[2], rotdeg_dorami * -1);
                rotate_dorami += rotdeg_dorami;
            }
            else
            {
                dorami.Child[2].rotate(dorami._center, dorami.Child[2]._euler[2], rotdeg_dorami);
                rotate_dorami -= rotdeg_dorami;
            }
        }

        protected override void OnLoad()
        {
            base.OnLoad();
            //Background 

            makeDorami();

            _camera = new Camera(new Vector3(0, 0, 2), Size.X / Size.Y);
            CursorGrabbed = true;
            //cone = new Asset3d();
            //cone.createHalfBall(0.5f, 0.5f, 0.5f, -1.0f, 0.0f, 0.5f, 800, 2000);
            //cone.setColor(new Vector3(255, 0, 0));
            dorami.load(Constant.PATH + "shader.vert", Constant.PATH + "shader.frag", Size.X, Size.Y);
            //cone.load(Constant.PATH + "shader.vert", Constant.PATH + "shader.frag", Size.X, Size.Y);
            //cam.addChildClass(cone);
            cam.addChildClass(dorami);

            GL.GetInteger(GetPName.MaxVertexAttribs, out int maxAttributeCount);
            Console.WriteLine($"Maximum number of vertex attributes supported : {maxAttributeCount}");
        }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Enable(EnableCap.DepthTest);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            _time += 9.0 * args.Time;
            Matrix4 temp = Matrix4.Identity;
            animateDorami();
            dorami.render(3, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Size.X, Size.Y);
            _camera.AspectRatio = Size.X / (float)Size.Y;
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);
            _camera.Fov = _camera.Fov - e.OffsetY;
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }
            if (KeyboardState.IsKeyDown(Keys.Up))
            {
                cam.rotate(cam._center, cam._euler[0], -5);
            }
            if (KeyboardState.IsKeyDown(Keys.Down))
            {
                cam.rotate(cam._center, cam._euler[0], 5);
            }
            if (KeyboardState.IsKeyDown(Keys.Left))
            {
                cam.rotate(cam._center, cam._euler[1], -5);
            }
            if (KeyboardState.IsKeyDown(Keys.Right))
            {
                cam.rotate(cam._center, cam._euler[1], 5);
            }
            if (KeyboardState.IsKeyDown(Keys.Q))
            {
                cam.rotate(cam._center, cam._euler[2], -5);
            }
            if (KeyboardState.IsKeyDown(Keys.E))
            {
                cam.rotate(cam._center, cam._euler[2], 5);
            }

            float cameraSpeed = 0.5f;
            if (KeyboardState.IsKeyDown(Keys.W))
            {
                _camera.Position += _camera.Front * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.S))
            {
                _camera.Position -= _camera.Front * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.A))
            {
                _camera.Position -= _camera.Right * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.D))
            {
                _camera.Position += _camera.Right * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.Space))
            {
                _camera.Position += _camera.Up * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.LeftShift))
            {
                _camera.Position -= _camera.Up * cameraSpeed * (float)args.Time;
            }

            if (KeyboardState.IsKeyDown(Keys.N))
            {
                var axis = new Vector3(0, 1, 0);
                _camera.Position -= _objectPos;
                _camera.Position = Vector3.Transform(
                    _camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, _rotationSpeed)
                    .ExtractRotation());
                _camera.Position += _objectPos;
                _camera._front = -Vector3.Normalize(_camera.Position
                    - _objectPos);
            }
            if (KeyboardState.IsKeyDown(Keys.Comma))
            {
                var axis = new Vector3(0, 1, 0);
                _camera.Position -= _objectPos;
                _camera.Yaw -= _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, -_rotationSpeed)
                    .ExtractRotation());
                _camera.Position += _objectPos;

                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }
            if (KeyboardState.IsKeyDown(Keys.K))
            {
                var axis = new Vector3(1, 0, 0);
                _camera.Position -= _objectPos;
                _camera.Pitch -= _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, _rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;
                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }
            if (KeyboardState.IsKeyDown(Keys.M))
            {
                var axis = new Vector3(1, 0, 0);
                _camera.Position -= _objectPos;
                _camera.Pitch += _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, -_rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;
                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }

            var mouse = MouseState;
            var sensitivity = 0.2f;

            if (_firstMove)
            {
                _lastPos = new Vector2(mouse.X, mouse.Y);
                _firstMove = false;
            }
            else
            {
                var deltaX = mouse.X - _lastPos.X;
                var deltaY = mouse.Y - _lastPos.Y;
                _lastPos = new Vector2(mouse.X, mouse.Y);
                _camera.Yaw += deltaX * sensitivity;
                _camera.Pitch -= deltaY * sensitivity;
            }
        }

        public Matrix4 generateArbRotationMatrix(Vector3 axis, Vector3 center, float degree)
        {
            var rads = MathHelper.DegreesToRadians(degree);

            var secretFormula = new float[4, 4] {
                { (float)Math.Cos(rads) + (float)Math.Pow(axis.X, 2) * (1 - (float)Math.Cos(rads)), axis.X* axis.Y * (1 - (float)Math.Cos(rads)) - axis.Z * (float)Math.Sin(rads),    axis.X * axis.Z * (1 - (float)Math.Cos(rads)) + axis.Y * (float)Math.Sin(rads),   0 },
                { axis.Y * axis.X * (1 - (float)Math.Cos(rads)) + axis.Z * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Y, 2) * (1 - (float)Math.Cos(rads)), axis.Y * axis.Z * (1 - (float)Math.Cos(rads)) - axis.X * (float)Math.Sin(rads),   0 },
                { axis.Z * axis.X * (1 - (float)Math.Cos(rads)) - axis.Y * (float)Math.Sin(rads),   axis.Z * axis.Y * (1 - (float)Math.Cos(rads)) + axis.X * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Z, 2) * (1 - (float)Math.Cos(rads)), 0 },
                { 0, 0, 0, 1}
            };
            var secretFormulaMatix = new Matrix4
            (
                new Vector4(secretFormula[0, 0], secretFormula[0, 1], secretFormula[0, 2], secretFormula[0, 3]),
                new Vector4(secretFormula[1, 0], secretFormula[1, 1], secretFormula[1, 2], secretFormula[1, 3]),
                new Vector4(secretFormula[2, 0], secretFormula[2, 1], secretFormula[2, 2], secretFormula[2, 3]),
                new Vector4(secretFormula[3, 0], secretFormula[3, 1], secretFormula[3, 2], secretFormula[3, 3])
            );

            return secretFormulaMatix;
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            if(e.Button == MouseButton.Left)
            {
                float _x, _y;
                _x = (MousePosition.X - Size.X / 2)/(Size.X/2);
                _y = (MousePosition.Y - Size.Y / 2) / (Size.Y / 2) * -1;

                Console.WriteLine("x = " + _x + " y = " + _y + "\n");
                //_object[3].updateMousePosition(_x, _y, 0);
            }
        }
    }
}
