import React, { useState, useEffect } from "react";
import axios from "axios";

function Sidebar() {
  const [error, setError] = useState(null);
  const [isLoaded, setIsLoaded] = useState(false);
  const [columns, setColumns] = useState([]);
  const [rows, setRows] = useState([]);

  useEffect(() => {
    axios.get("https://localhost:44393/crypto"}).then(
      (res) => {
        const data = res.data.datatable;
        console.log(data);

        mapDataToTable(data);

        setIsLoaded(true);
      },
      (error) => {
        setError(error);
        setIsLoaded(true);
      }
    );
  }, []);

  function mapDataToTable(data) {
    formatColumnNames(data.columns);

    var columnData = data.columns.map((col) => col.name);
    var [rowData] = data.data;

    setColumns(columnData);
    setRows(rowData);
  }

  function formatColumnNames(columns) {
    // TODD - Format column names
    console.log(columns);
  }

  if (error) {
    return <div>Error: {error.message}</div>;
  } else if (!isLoaded) {
    return <div>Loading...</div>;
  } else {
    return (
      <table className="table table-dark">
        <thead>
          <tr>
            {columns.map((col) => (
              <th>{col}</th>
            ))}
          </tr>
        </thead>
        <tbody>
          <tr>
            {rows.map((row) => (
              <td>{row}</td>
            ))}
          </tr>
        </tbody>
      </table>
    );
  }
}

export default Sidebar;
