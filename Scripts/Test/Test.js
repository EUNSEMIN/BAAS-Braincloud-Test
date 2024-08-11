let currentIndex = 0;

function slide(direction) {
  const container = document.getElementById('img-container');
  const images = container.getElementsByTagName('img');
  const totalImages = images.length;
  const visibleImages = Math.floor(container.offsetWidth / images[0].offsetWidth);
  const maxIndex = totalImages - visibleImages;

  if (direction === 'left') {
    currentIndex = Math.max(currentIndex - 2, 0);
  } else if (direction === 'right') {
    currentIndex = Math.min(currentIndex + 2, maxIndex);
  }

  const newTransformValue = -currentIndex * images[0].offsetWidth;
  container.style.transform = `translateX(${newTransformValue}px)`;
}
