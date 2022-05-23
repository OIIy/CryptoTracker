import React, { useState, useEffect } from "react";
import axios from "../../api/axios";

function CryptoTable() {
  const [error, setError] = useState(null);
  const [isLoaded, setIsLoaded] = useState(false);
  const [columns, setColumns] = useState([]);
  const [rows, setRows] = useState([]);
  const [tokens, setTokens] = useState({})

  useEffect(() => {
    // let isMounted = true;
    // const abortController = new AbortController();

    getCrypto();

    return () => {
      // isMounted = false;
      // abortController.abort();
    }
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

  function getCrypto() {
    axios.get("crypto", {
    }).then(
        (res) => {
          const data = res.data.datatable;

          setTokens(data);
          
          mapDataToTable(data);
  
          setIsLoaded(true);
        },
        (error) => {
          setError(error);
          setIsLoaded(true);
        }
      )
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

export default CryptoTable;
