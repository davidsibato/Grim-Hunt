﻿using UnityEngine;

namespace E7.NotchSolution
{
    /// <summary>
    ///     Like <see cref="SafeAdaptation"/> but use the current screen aspect ratio number instead.
    ///     The ratio is width/height ratio when on <b>landscape</b> orientation (e.g. 4/3, 16/9, 2/1)
    ///     regardless of your game's orientation.
    /// </summary>
    /// <remarks>
    ///     By default, the curve is setup so that lower aspect ratio (wider screen) is "normal"
    ///     and higher number (narrower screen) is "adapted".
    ///     So the leftmost node in the curve represents a device like an iPad.
    /// </remarks>
    [HelpURL("https://exceed7.com/notch-solution/components/adaptation/aspect-ratio-adaptation.html")]
    public class AspectRatioAdaptation : AdaptationBase
    {
        private float AspectRatio
        {
            get
            {
                var landscape = Screen.width > Screen.height;
                return landscape ? Screen.width / (float) Screen.height : Screen.height / (float) Screen.width;
            }
        }

        private void Reset()
        {
            ResetAdaptationToCurve(GenDefaultCurve());

            AnimationCurve GenDefaultCurve()
            {
                return new AnimationCurve(new Keyframe(4f / 3f, 0, 1.2f, 1.2f),
                    new Keyframe(16f / 9f, Mathf.InverseLerp(4 / 3f, 19.5f / 9f, 16 / 9f), 1.2f, 1.2f),
                    new Keyframe(19.5f / 9f, 1, 1.2f, 1.2f));
            }
        }

        /// <inheritdoc/>
        public override void Adapt()
        {
            base.Adapt(AspectRatio);
        }
    }
}
