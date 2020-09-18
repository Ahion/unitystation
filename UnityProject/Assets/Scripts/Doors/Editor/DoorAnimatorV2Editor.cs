﻿using System;
using UnityEngine;

namespace Doors.Editor
{
	using UnityEditor;

	[CustomEditor(typeof(DoorAnimatorV2))]
	public class DoorAnimatorV2Editor : Editor
	{
		private bool panel = false;
		private bool welded = false;
		private bool lights = true;


		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			if (!Application.isPlaying)
			{
				return;
			}

			DoorAnimatorV2 animator = (DoorAnimatorV2) target;
			lights = EditorGUILayout.Toggle(lights, "Enable or disable lights");

			if (GUILayout.Button("Toggle hacking panel"))
			{
				panel = !panel;

				if (panel)
				{
					animator.AddPanelOverlay();
				}
				else
				{
					animator.RemovePanelOverlay();
				}
			}

			if (GUILayout.Button("Toggle welded"))
			{
				welded = !welded;

				if (welded)
				{
					animator.AddWeldOverlay();
				}
				else
				{
					animator.RemoveWeldOverlay();
				}
			}

			#region Opening and closing
			GUILayout.Label("Opening and closing", "bold");
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("Test opening animation"))
			{
				animator.RequestAnimation(animator.PlayOpeningAnimation(panel, lights));
			}

			if (GUILayout.Button("Test closing animation"))
			{
				animator.RequestAnimation(animator.PlayClosingAnimation(panel, lights));
			}
			GUILayout.EndHorizontal();
			#endregion

			#region Lights
			GUILayout.Label("Lights", "bold");
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("Test denying animation"))
			{
				animator.RequestAnimation(animator.PlayDeniedAnimation());
			}

			if (GUILayout.Button("Test pressure warning"))
			{
				animator.RequestAnimation(animator.PlayPressureWarningAnimation());
			}

			if (GUILayout.Button("Test emergency"))
			{
				Debug.Log("Not implemented");
			}
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			if (GUILayout.Button("Test bolts On"))
			{
				animator.TurnOnBoltsLight();
			}
			if (GUILayout.Button("Test bolts Off"))
			{
				animator.TurnOffAllLights();
			}
			GUILayout.EndHorizontal();
			#endregion
		}
	}
}