using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;

namespace HanoiTower.Source.Renderer
{
    class Button
    {
        public Rectangle Bounds;
        public string Text;
        public Color BaseColor;
        public Color HoverColor;
        public Color TextColor;
        public int FontSize;

        public Button(float x, float y, float width, float height, string text,
                      Color baseColor, Color hoverColor, Color textColor, int fontSize)
        {
            Bounds = new Rectangle(x, y, width, height);
            Text = text;
            BaseColor = baseColor;
            HoverColor = hoverColor;
            TextColor = textColor;
            FontSize = fontSize;
        }

        public void Draw()
        {
            var mousePos = Raylib.GetMousePosition();
            bool hovered = Raylib.CheckCollisionPointRec(mousePos, Bounds);
            var currentColor = hovered ? HoverColor : BaseColor;
            Raylib.DrawRectangleRec(Bounds, currentColor);

            var textWidth = Raylib.MeasureText(Text, FontSize);
            var textX = Bounds.X + (Bounds.Width - textWidth) / 2;
            var textY = Bounds.Y + (Bounds.Height - FontSize) / 2;
            Raylib.DrawText(Text, (int)textX, (int)textY, FontSize, TextColor);
        }

        public bool IsClicked()
        {
            var mousePos = Raylib.GetMousePosition();
            return Raylib.CheckCollisionPointRec(mousePos, Bounds)
                   && Raylib.IsMouseButtonPressed(MouseButton.Left);
        }
    }
}