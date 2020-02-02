using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

// Reference: https://www.youtube.com/watch?v=vNqHRD4sqPc&list=PLmc6GPFDyfw85CcfwbB7ptNVJn5BSBaXz&index=3

public class UIButtonTransition : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public Color32 normalColor = Color.white;
    public Color32 hoverColor = Color.grey;
    public Color32 downColor = Color.blue;

    private Image m_image = null;

    bool mouseOver = false;
    bool mouseOverExit = false;
    Vector3 minScale;
    Vector3 currentScale;
    public Vector3 targetScale;
    public Vector3 maxScale;

    public GameObject credit = null;
    public GameObject spawnPos = null;

    private void Awake()
    {
        m_image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_image.color = hoverColor;

        mouseOver = true;
        mouseOverExit = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_image.color = normalColor;

        mouseOver = false;
        mouseOverExit = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(gameObject.tag == "Start")
        {
            SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
        }
        if (gameObject.tag == "Credit")
        {
            spawnCredit();
        }
        if (gameObject.tag == "Exit")
        {
            Application.Quit();
        }

        m_image.color = downColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        m_image.color = hoverColor;
    }

    void Update()
    {
        if (mouseOver)
        {
            minScale = transform.localScale;
            transform.localScale = Vector2.Lerp(minScale, maxScale, .25f);
        }

        if (mouseOverExit)
        {
            currentScale = transform.localScale;
            transform.localScale = Vector2.Lerp(currentScale, targetScale, .25f);
        }
    }

    private void spawnCredit()
    {
        Instantiate(credit, spawnPos.transform.position, Quaternion.identity);
    }
}
