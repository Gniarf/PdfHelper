﻿using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Data;
using iText.Kernel.Pdf.Canvas.Parser.Listener;

namespace PdfHelper.Models
{
    public class CustomTextRenderListener : LocationTextExtractionStrategy//ITextExtractionStrategy
    {
        /*public List<WordData> Words { get; } = new List<WordData>();

        public void EventOccurred(IEventData data, EventType type)
        {
            if (type == EventType.RENDER_TEXT)
            {
                TextRenderInfo renderInfo = (TextRenderInfo)data;

                // Loop through each character and create a WordCoordinates object for each word
                WordData word = new();
                foreach (TextRenderInfo charInfo in renderInfo.GetCharacterRenderInfos())
                {
                    Rectangle rect = charInfo.GetBaseline().GetBoundingRectangle();
                    float x1 = rect.GetX();
                    float y1 = rect.GetY();
                    float x2 = rect.GetX() + rect.GetWidth();
                    float y2 = rect.GetY() + rect.GetHeight();

                   *//* if (word == null)
                    {*//*
                        word = new WordData
                        {
                            Text = charInfo.GetText(),
                            X1 = x1,
                            Y1 = y1,
                            X2 = x2,
                            Y2 = y2
                        };
                    //}
                  *//*  else
                    {
                        word.Text += charInfo.GetText();
                        word.X2 = x2;
                        word.Y2 = y2;
                    }*//*
                }

                if (word != null)
                {
                    Words.Add(word);
                }
            }
        }

        public ICollection<EventType> GetSupportedEvents()
        {
            return new List<EventType> { EventType.RENDER_TEXT };
        }

        public string GetResultantText()
        {
            return string.Empty;
        }*/

        private List<WordData> wordDataList = new List<WordData>();

        public override void EventOccurred(IEventData data, EventType type)
        {
            if (type == EventType.RENDER_TEXT)
            {
                TextRenderInfo renderInfo = (TextRenderInfo)data;
                LineSegment baseline = renderInfo.GetBaseline();
                Rectangle rect = baseline.GetBoundingRectangle();

                WordData wordData = new WordData
                {
                    Text = renderInfo.GetText(),
                    X = rect.GetX(),
                    Y = rect.GetY(),
                    Width = rect.GetWidth(),
                    Height = rect.GetHeight()
                };

                wordDataList.Add(wordData);
            }
        }

        public List<WordData> GetWordDataList()
        {
            return wordDataList;
        }
    }
}
