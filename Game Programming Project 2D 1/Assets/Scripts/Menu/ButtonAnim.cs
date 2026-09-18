using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class ButtonAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float animDuration = 1f;
    [SerializeField] private Vector3 endValue = new Vector3(2,2,2);
    [SerializeField] private Vector3 startValue;

    private void Start()
    {
        startValue = transform.localScale;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOKill();
        transform.DOScale(endValue, animDuration).SetUpdate(true);
    }

    private void OnDisable()
    {
        transform.DOKill();
        transform.localScale = Vector3.one;
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOKill();
        transform.DOScale(startValue, animDuration).SetUpdate(true);
    }
}
