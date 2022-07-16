using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

namespace MoreMountains.Feedbacks
{
    /// <summary>
    /// This feedback will trigger a MMGameEvent of the specified name when played
    /// </summary>
    [AddComponentMenu("")]
    [FeedbackHelp("This feedback will trigger a MMGameEvent of the specified name when played")]
    [FeedbackPath("Events/MMGameEvent")]
    public class MMFeedbackMMGameEvent : MMFeedback
    {
        /// sets the inspector color for this feedback
#if UNITY_EDITOR
        public override Color FeedbackColor { get { return MMFeedbacksInspectorColors.EventsColor; } }
#endif

        public string MMGameEventName;

        /// <summary>
        /// On Play we change the values of our fog
        /// </summary>
        /// <param name="position"></param>
        /// <param name="feedbacksIntensity"></param>
        protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1.0f)
        {
            if (Active)
            {
                MMGameEvent.Trigger(MMGameEventName);
            }
        }
    }
}
