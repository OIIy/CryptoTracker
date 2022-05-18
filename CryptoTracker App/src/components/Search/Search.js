import React, { useState, useEffect } from "react";
import axios from "axios";

function Search() {
    return (
        <div className="input-group">
            <label for="coin-select" class="form-label">Datalist example</label>
            <input class="form-control" list="coinDatalist" id="coin-select" placeholder="Type to search..." />
            <datalist id="coinDatalist">
                <option value="San Francisco" />
                <option value="New York" />
                <option value="Seattle" />
                <option value="Los Angeles" />
                <option value="Chicago" />
            </datalist>

            <label for="pair-select" class="form-label">Datalist example</label>
            <input class="form-control" list="pairDatalist" id="pair-select" placeholder="Type to search..." />
            <datalist id="pairDatalist">
                <option value="San Francisco" />
                <option value="New York" />
                <option value="Seattle" />
                <option value="Los Angeles" />
                <option value="Chicago" />
            </datalist>
        </div>
        )
}

export default Search;