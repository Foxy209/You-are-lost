using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class graphics_settings : MonoBehaviour
{
	public Dropdown dropDown;

	void Start () {
		dropDown.ClearOptions();
		dropDown.AddOptions(QualitySettings.names.ToList());
		dropDown.value = QualitySettings.GetQualityLevel();

	}
	public void SetQuality () {
		QualitySettings.SetQualityLevel(dropDown.value);

}
}