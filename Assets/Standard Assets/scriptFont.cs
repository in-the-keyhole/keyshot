using UnityEngine;
using System.Collections;

public class scriptFont : MonoBehaviour {
	public static int GetSizeFromResolution() {
		int size = (int)(Screen.width * .016);
		if (SystemInfo.supportsAccelerometer) {
			size = (int)(Screen.width * .024);
		}

		if (size < 5) size = 5;
		return size;
	}
	
	public static string MakeString(string text) {
		int size = GetSizeFromResolution();
		return MakeString(text, size, null, false, false);
	}

	public static string MakeString(string text, string color, bool bold, bool italic) {
		int size = GetSizeFromResolution();
		return MakeString (text, size, color, bold, italic);
	}

	public static string MakeString(string text, string color) {
		int size = GetSizeFromResolution();
		return MakeString (text, size, color, false, false);
	}

	public static string MakeString(string text, int size) {
		return MakeString(text, size, null, false, false);
	}

	public static string MakeString(string text, int size, string color) {
		return MakeString(text, size, color, false, false);
	}

	public static string MakeString(string text, int size, string color, bool bold, bool italic) {
		string newText = "";
		newText = "<size=" + size + ">";
		
		if (color != null) {
			newText += "<color=" + color + ">";
		}

		if (bold) {
			newText += "<b>";
		}

		if (italic) {
			newText += "<i>";
		}

		newText += text;
		
		if (italic) {
			newText += "</i>";
		}
		
		if (bold) {
			newText += "</b>";
		}

		if (color != null) {
			newText += "</color>";
		}

		newText += "</size>";

		return newText;
	}
}
