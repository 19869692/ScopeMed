import React from "react";

export default function Dashboard() {
  return (
    <div>
      <h3 style={{ transform: "translate(39%, 10%)" }}>Dashboard - Summary</h3>
      <ul>
        <li>Recevied & Pending for assessment (3)</li>{" "}
        <li>Pending for quotation (5)</li>
        <li>Pending for approval (3)</li>
        <li>Reparing (6)</li>
        <li>Pending for QA (3)</li>
        <li>Pending for Shipping (5)</li>
        <li>Returned (10)</li>
      </ul>
    </div>
  );
}
