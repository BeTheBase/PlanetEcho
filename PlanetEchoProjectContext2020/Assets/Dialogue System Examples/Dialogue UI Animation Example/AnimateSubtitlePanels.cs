using UnityEngine;
using PixelCrushers.DialogueSystem;

public class AnimateSubtitlePanels : MonoBehaviour
{

    [Tooltip("Play this animator state in the subtitle panel's Animator to show the subtitle.")]
    public string show = "Show";

    [Tooltip("Play this animator state in the subtitle panel's Animator to hide the subtitle.")]
    public string hide = "Hide";

    private UnityUIDialogueUI dialogueUI;
    private Animator npcAnimator;
    private Animator pcAnimator;
    private bool hasInitializedPortraits;

    public void Awake()
    {
        dialogueUI = GetComponent<UnityUIDialogueUI>();
        npcAnimator = dialogueUI.dialogue.npcSubtitle.panel.GetComponent<Animator>();
        pcAnimator = dialogueUI.dialogue.pcSubtitle.panel.GetComponent<Animator>();
    }

    public void OnConversationStart(Transform actor)
    {
        hasInitializedPortraits = false;
    }

    public void OnConversationLine(Subtitle subtitle)
    {
        var isNPC = subtitle.speakerInfo.IsNPC;
        if (!hasInitializedPortraits)
        {
            hasInitializedPortraits = true;
            dialogueUI.dialogue.npcSubtitle.portraitImage.sprite = UITools.CreateSprite(isNPC ? subtitle.speakerInfo.portrait : subtitle.listenerInfo.portrait);
            dialogueUI.dialogue.pcSubtitle.portraitImage.sprite = UITools.CreateSprite(!isNPC ? subtitle.speakerInfo.portrait : subtitle.listenerInfo.portrait);
        }
        npcAnimator.Play(isNPC ? show : hide);
        pcAnimator.Play(!isNPC ? show : hide);
    }

    public void OnConversationResponseMenu(Response[] responses)
    {
        npcAnimator.Play(hide);
        pcAnimator.Play(show);
    }

}
