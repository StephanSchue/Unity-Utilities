GUIStyle guiStyle = new GUIStyle();
guiStyle.normal.textColor = Color.white;

if(t.interactionAnchors != null && t.interactionAnchors.Count > 0)
{
    foreach(Transform anchor in t.interactionAnchors)
    {
        if(anchor.gameObject.activeSelf)
        {
            Handles.Label(anchor.position, "Interaction Anchor", guiStyle);

            if(t is HideoutObject)
            {
                HideoutObject hideoutObject = t as HideoutObject;

                // --- Interaction Anchor Position ---
                Handles.DrawWireDisc(anchor.position, Vector3.up, t.InteractionDistance);
                Handles.DrawDottedLine(hideoutObject.GetHidingPosition().position, anchor.position, 1f);
                Handles.DrawSolidDisc(anchor.position, Vector3.up, 0.015f);

                Handles.DrawDottedLine(hideoutObject.GetHidingPosition().position, anchor.position, 1f);

                // --- Catch Anchor Position ---
                Handles.color = Color.red;
                Vector3 npcCatchEnterPosition = anchor.position + anchor.TransformVector(hideoutObject.catchOffset);
                Handles.DrawDottedLine(anchor.position, npcCatchEnterPosition, 1f);
                Handles.DrawSolidDisc(npcCatchEnterPosition, Vector3.up, 0.015f);
                Handles.color = Color.white;

                // --- Inspect Anchor Position ---
                Vector3 npcInspectEnterPosition = anchor.position + anchor.TransformVector(hideoutObject.inpsectOffset);
                Handles.color = Color.blue;
                Handles.DrawDottedLine(anchor.position, npcInspectEnterPosition, 1f);
                Handles.DrawSolidDisc(npcInspectEnterPosition, Vector3.up, 0.015f);
                Handles.color = Color.white;
            }
            else
            {
                Handles.DrawWireDisc(anchor.position, Vector3.up, t.InteractionDistance);
                Handles.DrawDottedLine(t.transform.position, anchor.position, 1f);
                Handles.DrawSolidDisc(anchor.position, Vector3.up, 0.015f);

                Handles.DrawDottedLine(t.transform.position, anchor.position, 1f);
            }
        }
    }
}