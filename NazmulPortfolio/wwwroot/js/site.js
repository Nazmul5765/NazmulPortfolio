Blazor.addEventListener("enhancedload", () => {
    window.scrollTo(0, 0);
});

async function downloadFile(url, filename) {
    try {
        const response = await fetch(url);
        if (!response.ok) throw new Error("Network response was not ok");

        const blob = await response.blob();
        const blobUrl = URL.createObjectURL(blob);

        const link = document.createElement("a");
        link.href = blobUrl;
        link.download = filename;
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);

        URL.revokeObjectURL(blobUrl);
    } catch {
        window.location.href = url;
    }
}
