﻿using OpenTK.Windowing.Desktop;
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
        Asset3d body;
        Asset3d main_head;
        Asset3d cone;
        Asset3d right_hand;
        Asset3d left_hand;
        Asset3d right_foot;
        Asset3d left_foot;
        Asset3d cam = new Asset3d();
        float degree = 0;
        double _time = 0;
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {

        }

        public void makeBody()
        {
            //Ganti Background
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            _object3d[0] = new Asset3d();
            body = new Asset3d();

            //Badan
            _object3d[0] = new Asset3d();
            _object3d[0].createEllipsoid2(0.5f, 0.5f, 0.5f, 0.0f, 0.0f, 0.0f, 300, 100);
            _object3d[0].setColor(new Vector3(255, 228, 59));
            body.addChildClass(_object3d[0]);

            //Outline bg kantong
            //_object3d[1] = new Asset3d();
            //_object3d[1].createEllipsoid2(0.42f, 0.40f, 0.30f, 0.0f, 0.0f, 0.2f, 300, 100);
            //_object3d[1].setColor(new Vector3(0, 0, 0));
            //body.addChildClass(_object3d[1]);

            //bg kantong
            //_object3d[2] = new Asset3d();
            //_object3d[2].createEllipsoid2(0.40f, 0.38f, 0.25f, 0.0f, 0.0f, 0.25f, 300, 100);
            //_object3d[2].setColor(new Vector3(255, 255, 255));
            //body.addChildClass(_object3d[2]);

            //Outline Kantong
            _object3d[3] = new Asset3d();
            _object3d[3].createHalfBall(0.3f, 0.3f, 0.03f, 0.0f, -0.15f, 0.475f, 800, 2000);
            _object3d[3].rotate(_object3d[0]._center, _object3d[0]._euler[2], 180);
            _object3d[3].rotate(_object3d[0]._center, _object3d[0]._euler[0], 10);
            _object3d[3].setColor(new Vector3(0, 0, 0));
            body.addChildClass(_object3d[3]);

            //kantong
            _object3d[4] = new Asset3d();
            _object3d[4].createHalfBall(0.28f, 0.28f, 0.0f, 0.0f, -0.2f, 0.5f, 800, 2000);
            _object3d[4].rotate(_object3d[0]._center, _object3d[0]._euler[2], 180);
            _object3d[4].rotate(_object3d[0]._center, _object3d[0]._euler[0], 15);
            _object3d[4].setColor(new Vector3(255, 255, 255));
            body.addChildClass(_object3d[4]);

            //kalung lonceng
            _object3d[5] = new Asset3d();
            _object3d[5].createEllipsoid2(0.5f, 0.08f, 0.5f, 0.0f, 0.29f, 0.0f, 300, 100);
            _object3d[5].setColor(new Vector3(2, 160, 231));
            body.addChildClass(_object3d[5]);


            //bg lonceng
            _object3d[6] = new Asset3d();
            _object3d[6].createEllipsoid2(0.11f, 0.01f, 0.11f, 0.0f, 0.19f, 0.55f, 300, 100);
            _object3d[6].setColor(new Vector3(255, 165, 0));
            body.addChildClass(_object3d[6]);

            //Lonceng
            _object3d[7] = new Asset3d();
            _object3d[7].createEllipsoid2(0.1f, 0.1f, 0.1f, 0.0f, 0.19f, 0.55f, 300, 100);
            _object3d[7].setColor(new Vector3(255, 255, 0));
            body.addChildClass(_object3d[7]);

            ////kalung lonceng
            //_object3d[5] = new Asset3d();
            //_object3d[5].createEllipsoid2(0.5f, 0.08f, 0.5f, 0.0f, 0.29f, 0.0f, 300, 100);
            //_object3d[5].setColor(new Vector3(255, 0, 0));
            //body.addChildClass(_object3d[5]);


            //_object3d[5] = new Asset3d();
            //_object3d[5].EllipCone(0.1f, 0.1f, 0.1f, 0.9f, 0, 0);
            //_object3d[5].setColor(new Vector3(255, 0, 0));
            //body.addChildClass(_object3d[5]);

            //_object3d[5] = new Asset3d();
            //_object3d[5].createEllipsoid2(0.03f, 0.05f, 0.1f, -0.7f, 0.29f, 0.0f, 300, 100);
            //_object3d[5].setColor(new Vector3(255, 0, 0));
            //body.addChildClass(_object3d[5]);

            //bg lonceng
            //_object3d[6] = new Asset3d();
            //_object3d[6].createEllipsoid2(0.11f, 0.01f, 0.11f, 0.0f, 0.19f, 0.55f, 300, 100);
            //_object3d[6].setColor(new Vector3(255, 165, 0));
            //body.addChildClass(_object3d[6]);

            ////Hem baju
            //_object3d[1] = new Asset3d();
            //                                        //x   //z   //y
            //_object3d[1].EllipCone(0.14f, 0.02f, 0.15f, 0f, -0.5f, -0.1f);
            //_object3d[1].setColor(new Vector3(0, 0, 0));
            //_object3d[1].rotate(_object3d[0]._center, _object3d[0]._euler[0], -105);
            //_object3d[1].rotate(_object3d[0]._center, _object3d[0]._euler[1], 0);

            //body.addChildClass(_object3d[1]);

            ////Hem baju
            //_object3d[1] = new Asset3d();
            //                                        //x   //z   //y
            //_object3d[1].EllipCone(0.1f, 0.01f, 0.145f, 0f, -0.51f, -0.05f);
            //_object3d[1].setColor(new Vector3(255, 255, 255));
            //_object3d[1].rotate(_object3d[0]._center, _object3d[0]._euler[0], -100);
            ////_object3d[1].rotate(_object3d[0]._center, _object3d[0]._euler[1], 25);

            //body.addChildClass(_object3d[1]);

            ////Lonceng
            //_object3d[7] = new Asset3d();
            //_object3d[7].createEllipsoid2(0.03f, 0.03f, 0.03f, 0.0f, 0.3f, 0.55f, 300, 100);
            //_object3d[7].setColor(new Vector3(171, 57, 96));
            //body.addChildClass(_object3d[7]);

            //_object3d[7] = new Asset3d();
            //_object3d[7].EllipCone(0.03f, 0.05f, 0.1f, -0.55f, 0.30f, 0f);
            //_object3d[7].setColor(new Vector3(171, 57, 96));
            //_object3d[7].rotate(_object3d[0]._center, _object3d[0]._euler[1], 90);
            //body.addChildClass(_object3d[7]);

            //_object3d[7] = new Asset3d();
            //_object3d[7].EllipCone(0.03f, 0.05f, 0.1f, 0.55f, 0.30f, 0f);
            //_object3d[7].setColor(new Vector3(171, 57, 96));
            //_object3d[7].rotate(_object3d[0]._center, _object3d[0]._euler[1], -90);
            //body.addChildClass(_object3d[7]);


        }

        public void makeHead()
        {
            main_head = new Asset3d();
            //main_head.createElipseoid(0.5f, 0.45f, 0.4f, 0.5f, 0.5f, 0.5f);
            main_head.createEllipsoid2(0.5f, 0.45f, 0.5f, 0.0f, 0.0f, 0.0f, 300, 100);
            main_head.setColor(new Vector3(253, 229, 63));

            Asset3d eyes = new Asset3d();

            eyes.createEllipsoid2(0.1f, 0.15f, 0.1f, -0.1f, 0.05f, 0.4f, 300, 100);
            eyes.setColor(new Vector3(255.0f, 255.0f, 255.0f));
            main_head.addChildClass(eyes);

            eyes = new Asset3d();
            eyes.createEllipsoid2(0.1f, 0.15f, 0.1f, 0.1f, 0.05f, 0.4f, 300, 100);
            eyes.setColor(new Vector3(255.0f, 255.0f, 255.0f));
            main_head.addChildClass(eyes);

            eyes = new Asset3d();
            eyes.createEllipsoid2(0.1f / 3f, 0.15f / 3f, 0.05f / 3f, 0.10f, 0.05f, 0.5f, 300, 100);
            eyes.setColor(new Vector3(0.0f, 0.0f, 0.0f));
            main_head.addChildClass(eyes);

            eyes = new Asset3d();
            eyes.createEllipsoid2(0.1f / 3f, 0.15f / 3f, 0.05f / 3f, -0.10f, 0.05f, 0.5f, 300, 100);
            eyes.setColor(new Vector3(0.0f, 0.0f, 0.0f));
            main_head.addChildClass(eyes);
            Asset3d cheek = new Asset3d();
            Asset3d smile = new Asset3d();
            Asset3d nose = new Asset3d();
            cheek.createEllipsoid2(0.35f, 0.23f, 0.05f, 0.0f, 0.05f, 0.44f, 300, 100);
            cheek.setColor(new Vector3(255f, 255f, 255f));
            cheek.rotate(main_head._center, main_head._euler[0], 35);

            nose.createEllipsoid2(0.075f, 0.055f, 0.075f, 0.0f, -0.1f, 0.45f, 300, 100);
            nose.setColor(new Vector3(251, 207, 208));

            smile.createHalfBall(0.2f, 0.15f, 0f, 0.0f, -0.1f, 0.5f, 800, 2000);
            smile.setColor(new Vector3(255f, 0f, 0f));
            smile.rotate(main_head._center, main_head._euler[2], 180);
            smile.rotate(main_head._center, main_head._euler[0], 35);
            main_head.addChildClass(smile);
            //main_head.addChildClass(cheek);
            main_head.addChildClass(nose);
            //Asset3d mustache;
            ////Right Mustache
            //mustache = new Asset3d();
            //mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, -0.52f, -0.12f, 0.1f);
            //mustache.setColor(new Vector3(0, 0, 0));
            //mustache.rotate(main_head._center, mustache._euler[1], 90);
            //mustache.rotate(main_head._center, mustache._euler[0], -15);
            //main_head.addChildClass(mustache);

            //mustache = new Asset3d();
            //mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, -0.5f, -0.12f, 0.1f);
            //mustache.setColor(new Vector3(0, 0, 0));
            //mustache.rotate(main_head._center, mustache._euler[1], 90);
            //main_head.addChildClass(mustache);

            //mustache = new Asset3d();
            //mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, -0.5f, -0.12f, 0.15f);
            //mustache.setColor(new Vector3(0, 0, 0));
            //mustache.rotate(main_head._center, mustache._euler[1], 90);
            //mustache.rotate(main_head._center, mustache._euler[0], 15);
            //main_head.addChildClass(mustache);

            ////Left Mustache
            //mustache = new Asset3d();
            //mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, 0.49f, -0.12f, 0.13f);
            //mustache.setColor(new Vector3(0, 0, 0));
            //mustache.rotate(main_head._center, mustache._euler[1], -90);
            //mustache.rotate(main_head._center, mustache._euler[0], 15);
            //main_head.addChildClass(mustache);

            //mustache = new Asset3d();
            //mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, 0.5f, -0.12f, 0.1f);
            //mustache.setColor(new Vector3(0, 0, 0));
            //mustache.rotate(main_head._center, mustache._euler[1], -90);
            //main_head.addChildClass(mustache);

            //mustache = new Asset3d();
            //mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, 0.52f, -0.12f, 0.08f);
            //mustache.setColor(new Vector3(0, 0, 0));
            //mustache.rotate(main_head._center, mustache._euler[1], -90);
            //mustache.rotate(main_head._center, mustache._euler[0], -15);
            //main_head.addChildClass(mustache);

            //mustache = new Asset3d();
            //mustache.EllipPara(0.01f / 9f, 0.01f / 15f, 0.0014f, 0f, 0.53f, -0.115f);
            //mustache.setColor(new Vector3(0, 0, 0));
            //mustache.rotate(main_head._center, mustache._euler[0], 110);
            //main_head.addChildClass(mustache);

            Asset3d ears;
            //right ear
            ears = new Asset3d();
            ears.EllipPara(0.021f, 0.021f, 0.004f, -0.07f, 0f, -0.76f);
            ears.rotate(main_head._center, ears._euler[0], 90);
            ears.rotate(main_head._center, ears._euler[1], 15);
            ears.setColor(new Vector3(225, 0, 42));
            main_head.addChildClass(ears);
            //left ear
            ears = new Asset3d();
            ears.EllipPara(0.021f, 0.021f, 0.004f, 0.07f, 0f, -0.76f);
            ears.rotate(main_head._center, ears._euler[0], 90);
            ears.rotate(main_head._center, ears._euler[1], -15);
            ears.setColor(new Vector3(225, 0, 42));
            main_head.addChildClass(ears);

            ////inner right ear
            //ears = new Asset3d();
            //ears.EllipPara(0f, 0.021f / 1.5f, 0.004f, 0.3193f, -0.1f, -0.58f);
            //ears.rotate(main_head._center, ears._euler[0], 70);
            //ears.rotate(main_head._center, ears._euler[1], -15);
            //ears.rotate(main_head._center, ears._euler[2], 90);
            //ears.setColor(new Vector3(210, 210, 183));
            //main_head.addChildClass(ears);
            ////inner left ear
            //ears = new Asset3d();
            //ears.EllipPara(0f, 0.021f / 1.5f, 0.004f, 0.3193f, 0.1f, -0.58f);
            //ears.rotate(main_head._center, ears._euler[0], 70);
            //ears.rotate(main_head._center, ears._euler[1], 15);
            //ears.rotate(main_head._center, ears._euler[2], 90);
            //ears.setColor(new Vector3(210, 210, 183));
            //main_head.addChildClass(ears);
        }

        public void makeHand()
        {
            //right hand
            right_hand = new Asset3d();
            right_hand.createEllipsoid2(0.12f, 0.12f, 0.12f, 0.55f, -0.3f, 0.0f, 300, 100);
            right_hand.setColor(new Vector3(211, 211, 211));
            //right arm
            Asset3d arm = new Asset3d();
            arm.EllipPara(0.011f, 0.011f, 0.004f, 0.45f, 0f, 0f);
            arm.setColor(new Vector3(255, 200, 59));
            arm.rotate(right_hand._center, arm._euler[0], 90);
            arm.rotate(right_hand._center, arm._euler[1], 15);
            right_hand.addChildClass(arm);

            //left hand
            left_hand = new Asset3d();
            left_hand.createEllipsoid2(0.12f, 0.12f, 0.12f, -0.55f, -0.3f, 0.0f, 300, 100);
            left_hand.setColor(new Vector3(211, 211, 211));
            //left arm
            arm = new Asset3d();
            arm.EllipPara(0.011f, 0.011f, 0.004f, -0.45f, 0f, 0f);
            arm.setColor(new Vector3(255, 200, 59));
            arm.rotate(right_hand._center, arm._euler[0], 90);
            arm.rotate(right_hand._center, arm._euler[1], -15);
            left_hand.addChildClass(arm);
        }

        public void makeFoot()
        {
            //right foot
            right_foot = new Asset3d();
            right_foot.createEllipsoid2(0.2f, 0.1f, 0.2f, 0.2f, -0.75f, 0.0f, 300, 100);
            right_foot.setColor(new Vector3(211, 211, 211));
            //right leg
            Asset3d leg = new Asset3d();
            leg.createHalfBall(0.15f, 0.4f, 0.15f, 0.2f, -0.7f, 0.0f, 800, 2000);
            leg.setColor(new Vector3(255, 200, 59));
            right_foot.addChildClass(leg);

            //left foot
            left_foot = new Asset3d();
            left_foot.createEllipsoid2(0.2f, 0.1f, 0.2f, -0.2f, -0.75f, 0.0f, 300, 100);
            left_foot.setColor(new Vector3(211, 211, 211));
            //left leg
            leg = new Asset3d();
            leg.createHalfBall(0.15f, 0.4f, 0.15f, -0.2f, -0.7f, 0.0f, 800, 2000);
            leg.setColor(new Vector3(255, 200, 59));
            right_foot.addChildClass(leg);
        }

        protected override void OnLoad()
        {
            base.OnLoad();
            //Background 

            makeHead();
            makeBody();
            makeHand();
            makeFoot();
            
            //cone = new Asset3d();
            //cone.createHalfBall(0.5f, 0.5f, 0.5f, -1.0f, 0.0f, 0.5f, 800, 2000);
            //cone.setColor(new Vector3(255, 0, 0));

            main_head.load(Constant.PATH + "shader.vert", Constant.PATH + "shader.frag", Size.X, Size.Y);
            body.load(Constant.PATH + "shader.vert", Constant.PATH + "shader.frag", Size.X, Size.Y);
            right_hand.load(Constant.PATH + "shader.vert", Constant.PATH + "shader.frag", Size.X, Size.Y);
            left_hand.load(Constant.PATH + "shader.vert", Constant.PATH + "shader.frag", Size.X, Size.Y);
            right_foot.load(Constant.PATH + "shader.vert", Constant.PATH + "shader.frag", Size.X, Size.Y);
            left_foot.load(Constant.PATH + "shader.vert", Constant.PATH + "shader.frag", Size.X, Size.Y);
            //cone.load(Constant.PATH + "shader.vert", Constant.PATH + "shader.frag", Size.X, Size.Y);
            //cam.addChildClass(cone);
            main_head.translateObject(0.5f);
            body.translateObject(-0.15f);
            cam.addChildClass(main_head);
            cam.addChildClass(body);
            cam.addChildClass(right_hand);
            cam.addChildClass(left_hand);
            cam.addChildClass(right_foot);
            cam.addChildClass(left_foot);

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
            //main_head.rotate(main_head._center, main_head._euler[1], 1);
            //smile.rotate(main_head._center, main_head._euler[2], 180);
            main_head.render(3, temp);
            body.render(3, temp);
            right_hand.render(3, temp);
            left_hand.render(3, temp);
            right_foot.render(3, temp);
            left_foot.render(3, temp);
            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Size.X, Size.Y);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            if (KeyboardState.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.Escape))
            {
                Close();
            }
            if (KeyboardState.IsKeyReleased(OpenTK.Windowing.GraphicsLibraryFramework.Keys.A))
            {
                Console.Write("Hello Glenn \n");
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
