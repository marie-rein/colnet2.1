window.toggleEditable = function (button) {
    var row = button.parentNode; // Start from the parent of the button

    // Traverse up the DOM until we find a 'tr' element
    while (row && row.tagName !== 'tr') {
        row = row.parentNode;
    }

    // If 'tr' is found, toggle contentEditable for cells with the class "editable-cell"
    if (row) {
        var cells = row.getElementsByClassName("editable-cell");

        for (var i = 0; i < cells.length; i++) {
            var cell = cells[i];
            cell.contentEditable = cell.contentEditable === "true" ? "false" : "true";
        }
    }
};
