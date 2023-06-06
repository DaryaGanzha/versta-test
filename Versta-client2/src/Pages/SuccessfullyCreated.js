import React from "react";

function SuccessfullyCreated(props) {
  const { onClose } = props;

  return (
    <div className="SuccessfullyCreated">
      <p>Заказ успешно создан!</p>
      <button className="btn btn-secondary" onClick={onClose}>Закрыть</button>
    </div>
  );
}

export default SuccessfullyCreated;