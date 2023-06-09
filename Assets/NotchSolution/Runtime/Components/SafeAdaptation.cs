﻿using UnityEngine;
using UnityEngine.Playables;

namespace E7.NotchSolution
{
    /// <summary>
    ///     <para>
    ///         Adapt anything according to how much a screen space was taken by a single side of safe area.
    ///     </para>
    ///     <para>
    ///         It uses Playables API and animation playables to blend between <b>the first frame</b>
    ///         of 2 <see cref="AnimationClip"/>, which represent normal state and fully-adapted state.
    ///         As long as something is keyable by the animation system, it could be adapted to the safe area.
    ///     </para>
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Blend amount is 0 ~ 1, calculated from 0 ~ 1 relative screen space taken of a single side that is then
    ///         evaluated through configurable <see cref="BlendedClipsAdaptor.adaptationCurve"/>.
    ///     </para>
    ///     <para>
    ///         By using animation system, the modification won't count as dirtying the scene which is great
    ///         when you want to switching the simulator on and off just to observe its effect.
    ///     </para>
    ///     <para>
    ///         Animator is needed for its field binding power but no need for the controller asset,
    ///         because we don't need the costly state machine, just like how <see cref="PlayableDirector"/> works with
    ///         animation playables.
    ///     </para>
    ///     <para>
    ///         However since Unity can't design <see cref="AnimationClip"/> on
    ///         the Animation pane without <see cref="Animation"/> <b>with</b> controllers, you may need to temporarily
    ///         add a controller when you are making the clip + add clips as some states in the animation graph,
    ///         then remove the controller once you finished making the clip...
    ///     </para>
    ///     <para>
    ///         At runtime it only take effect on <c>Start</c>, since safe area is not expected to change dynamically,
    ///         and unlike uGUI layout system + <see cref="SafePadding"/>, a frequent recalculation is not expected.
    ///         Call <see cref="Adapt"/> if you wish to apply the adaptation manually again.
    ///     </para>
    ///     <para>
    ///         In edit mode, it also apply on notch simulator update. So it is almost like the adaptation always lock your fields.
    ///         In real play it is possible to adjust these adapted fields later freely since it's only on <c>Start</c>.
    ///     </para>
    /// </remarks>
    [HelpURL("https://exceed7.com/notch-solution/components/adaptation/safe-adaptation.html")]
    public class SafeAdaptation : AdaptationBase
    {
        //Currently I think iPhone X has the largest notch, so this should be a good default upper bound of blend value.
        private const float iPhoneXNotchHeightRelative = 0.05418718f;

#if UNITY_EDITOR
        public float latestSimulatedSpaceTakenRelative;
#endif

        private void Reset()
        {
            ResetAdaptationToCurve(AnimationCurve.Linear(0, 0, iPhoneXNotchHeightRelative, 1));
        }

        /// <summary>
        ///     At runtime <see cref="SafeAdaptation"/> only take effect on `Start`, since safe area is not expected to change dynamically,
        ///     and unlike uGUI and <see cref="SafePadding"/>  a frequent recalculation is not expected.
        ///     This method applies that adaptation manually again.
        /// </summary>
        public override void Adapt()
        {
            AdaptWithRelativeSafeArea(SafeAreaRelative);
        }

        private void AdaptWithRelativeSafeArea(Rect relativeSafeArea)
        {
            float spaceTakenRelative = 0;

            if (evaluationMode != EdgeEvaluationMode.Off)
            {
                switch (adaptToEdge)
                {
                    case RectTransform.Edge.Left:
                        spaceTakenRelative = relativeSafeArea.xMin;
                        break;
                    case RectTransform.Edge.Right:
                        spaceTakenRelative = 1 - relativeSafeArea.xMax;
                        break;
                    case RectTransform.Edge.Top:
                        spaceTakenRelative = 1 - relativeSafeArea.yMax;
                        break;
                    case RectTransform.Edge.Bottom:
                        spaceTakenRelative = relativeSafeArea.yMin;
                        break;
                }

                if (evaluationMode == EdgeEvaluationMode.Balanced)
                {
                    switch (adaptToEdge)
                    {
                        case RectTransform.Edge.Left:
                            spaceTakenRelative = Mathf.Max(spaceTakenRelative, 1 - relativeSafeArea.xMax);
                            break;
                        case RectTransform.Edge.Right:
                            spaceTakenRelative = Mathf.Max(spaceTakenRelative, relativeSafeArea.xMin);
                            break;
                        case RectTransform.Edge.Top:
                            spaceTakenRelative = Mathf.Max(spaceTakenRelative, relativeSafeArea.yMin);
                            break;
                        case RectTransform.Edge.Bottom:
                            spaceTakenRelative = Mathf.Max(spaceTakenRelative, 1 - relativeSafeArea.yMax);
                            break;
                    }
                }
            }

#if UNITY_EDITOR
            latestSimulatedSpaceTakenRelative = spaceTakenRelative;
#endif


            base.Adapt(spaceTakenRelative);

            //Debug.Log($"Evaluated! Got blend {blend} from {spaceTakenRelative} space taken (Relative safe area {relativeSafeArea.xMin} {relativeSafeArea.xMax} {relativeSafeArea.yMin} {relativeSafeArea.yMax})");
        }
#pragma warning disable 0649
        [SerializeField]
        private RectTransform.Edge adaptToEdge;

        [SerializeField]
        private EdgeEvaluationMode evaluationMode;
#pragma warning restore 0649
    }
}
