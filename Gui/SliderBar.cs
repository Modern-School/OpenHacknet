﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hacknet.Gui
{
	// Token: 0x0200011F RID: 287
	public static class SliderBar
	{
		// Token: 0x060006BD RID: 1725 RVA: 0x0006E970 File Offset: 0x0006CB70
		public static float doSliderBar(int myID, int x, int y, int width, int height, float maxValue, float minValue, float currentValue, float barStep)
		{
			float num = -1f;
			float num2 = currentValue;
			if (GuiData.hot == myID)
			{
				if (GuiData.isMouseLeftDown())
				{
					GuiData.active = myID;
				}
				else if (GuiData.active == myID)
				{
					GuiData.active = -1;
				}
				if (GuiData.active == myID)
				{
					num = (float)(GuiData.mouse.X - x) / (float)width;
					num = Math.Min(Math.Max(num, 0f), 1f);
					num2 = minValue + num * (maxValue - minValue);
				}
				num2 += barStep * GuiData.getMouseWheelScroll();
			}
			if (num == -1f)
			{
				float num3 = maxValue - minValue;
				num = currentValue / num3;
				if (minValue < 0f)
				{
					num += 0.5f;
				}
			}
			GuiData.tmpRect.X = x;
			GuiData.tmpRect.Y = y;
			GuiData.tmpRect.Width = width;
			GuiData.tmpRect.Height = height;
			if (GuiData.tmpRect.Contains(GuiData.getMousePoint()))
			{
				GuiData.hot = myID;
			}
			else if (GuiData.hot == myID && GuiData.mouse.LeftButton == ButtonState.Released)
			{
				GuiData.hot = -1;
				if (GuiData.active == myID)
				{
					GuiData.active = -1;
				}
			}
			num2 = Math.Min(Math.Max(num2, minValue), maxValue);
			GuiData.tmpRect.Width = width;
			GuiData.tmpRect.X = x;
			GuiData.tmpRect.Height = 10;
			GuiData.tmpRect.Y = y + height / 4;
			GuiData.spriteBatch.Draw(Utils.white, GuiData.tmpRect, GuiData.Default_Backing_Color);
			GuiData.tmpRect.Width = GuiData.tmpRect.Width - 4;
			GuiData.tmpRect.X = GuiData.tmpRect.X + 2;
			GuiData.tmpRect.Height = GuiData.tmpRect.Height - 4;
			GuiData.tmpRect.Y = GuiData.tmpRect.Y + 2;
			GuiData.spriteBatch.Draw(Utils.white, GuiData.tmpRect, GuiData.Default_Dark_Background_Color);
			GuiData.tmpRect.Width = 8;
			GuiData.tmpRect.X = (int)((float)x + num * (float)width) - 4;
			GuiData.tmpRect.Y = y - 5;
			GuiData.tmpRect.Height = height;
			GuiData.spriteBatch.Draw(Utils.white, GuiData.tmpRect, (GuiData.active != myID) ? ((GuiData.hot == myID) ? GuiData.Default_Lit_Backing_Color : GuiData.Default_Selected_Color) : GuiData.Default_Unselected_Color);
			if (GuiData.active == myID || GuiData.hot == myID)
			{
				string format = "0.000";
				string text = num2.ToString(format) ?? "";
				text.TrimEnd(new char[]
				{
					'0'
				});
				GuiData.temp.X = (float)((int)((float)x + num * (float)width) + 4);
				GuiData.temp.Y = (float)y - GuiData.smallfont.MeasureString(text).Y * 0.8f;
				GuiData.spriteBatch.DrawString(GuiData.smallfont, text, GuiData.temp + Vector2.One, Color.Gray, 0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.51f);
				GuiData.spriteBatch.DrawString(GuiData.smallfont, text, GuiData.temp, Color.White, 0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.5f);
			}
			return num2;
		}

		// Token: 0x04000799 RID: 1945
		public const int SELECTOR_BAR_WIDTH = 8;

		// Token: 0x0400079A RID: 1946
		public const int BOARDER = 2;

		// Token: 0x0400079B RID: 1947
		public const int SLIDE_BAR_HEIGHT = 10;
	}
}
