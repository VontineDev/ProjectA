using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UI_HudText : MonoBehaviour
{
    public UILabel lbDamage;
    public System.Action OnTweenEndCall;
    public void Init(UIRoot uIRoot, Vector3 pos, float damage)
    {
        lbDamage.text = damage.ToString();
        this.transform.SetParent(uIRoot.transform);
        this.transform.localScale = new Vector3(1, 1, 1);
        this.transform.localPosition = pos;
    }
    public void Play()
    {
        var pos = this.transform.position;
        pos.y += 0.2F;
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(this.transform.DOMove(pos, 0.3f));
        mySequence.Join(this.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.3f));

        mySequence.AppendCallback(() =>
       {
           OnTweenEndCall();
       });
        mySequence.Play();
    }
    public void Play2()
    {
        var pos = this.transform.position;
        pos.y += 0.2F;
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(this.transform.DOScale(new Vector3(1.6f, 1.6f, 1.6f), 0.3f));
        //mySequence.Append(this.transform.DOScale(Vector3.one, 0.1f));       
        mySequence.AppendCallback(() =>
        {
            OnTweenEndCall();
        });
        mySequence.Play();
    }
    public void Play3()
    {
        var pos = this.transform.position;
        pos.y += 0.2F;
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(this.transform.DOScale(new Vector3(1.6f, 1.6f, 1.6f), 0.3f));
        //mySequence.Append(this.transform.DOScale(Vector3.one, 0.1f));       
        mySequence.AppendCallback(() =>
        {
            OnTweenEndCall();
        });
        mySequence.Play();
    }

}
