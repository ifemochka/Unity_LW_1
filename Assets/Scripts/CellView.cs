using UnityEngine;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    private Cell cell;
    private Text cellText;

    void Awake()
    {
        cellText = GetComponentInChildren<Text>();
    }

    public void Init(Cell cell)
    {
        this.cell = cell;
        UpdateValue(cell.Value);
        UpdatePosition(cell.Position);

        cell.OnValueChanged += UpdateValue;
        cell.OnPositionChanged += UpdatePosition;
    }

    private void UpdateValue(int newValue)
    {
        cellText.text = Mathf.Pow(newValue, 2).ToString();
    }

    private void UpdatePosition(Vector2Int newPosition)
    {
        transform.localPosition = new Vector3(newPosition.x, newPosition.y, 0);
    }
}
