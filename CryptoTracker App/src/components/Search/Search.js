import React, { useState, useEffect } from "react";
import axios from "axios";

function Search() {
    return (
        <div className="input-group">
            <select className="form-select" aria-label="Select your token">
                <option defaultValue={true}>Select Token</option>
                <option value="1">One</option>
                <option value="2">Two</option>
                <option value="3">Three</option>
            </select>

            <select className="form-select" aria-label="Select your token pair">
                <option defaultValue={true}>Select Pair</option>
                <option value="1">One</option>
                <option value="2">Two</option>
                <option value="3">Three</option>
            </select>
        </div>
        )
}

export default Search;