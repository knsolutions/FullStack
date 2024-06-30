import React, { useEffect, useState } from "react";
import { apiService } from "../services";

interface DataType {
  id: number;
  key: string;
  value: string;
}

export const ExampleComponent: React.FC = () => {
  const [data, setData] = useState<DataType | null>(null);

  useEffect(() => {
    // Set the authorization token
    apiService.setAuthToken("your-token-here");

    // Example GET request with query parameters
    const fetchData = async () => {
      try {
        const result = await apiService.get<DataType>("/endpoint", {
          filter: "value",
        });
        setData(result);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };

    fetchData();
  }, []);

  const handlePost = async () => {
    try {
      const result = await apiService.post<DataType, { key: string }>(
        "/endpoint",
        { key: "value" }
      );
      console.log("Post result:", result);
    } catch (error) {
      console.error("Error posting data:", error);
    }
  };

  const handlePut = async () => {
    try {
      const result = await apiService.put<DataType, { key: string }>(
        "/endpoint",
        1,
        { key: "updatedValue" }
      );
      console.log("Put result:", result);
    } catch (error) {
      console.error("Error updating data:", error);
    }
  };

  const handleDelete = async () => {
    try {
      const result = await apiService.delete<DataType>("/endpoint", 1);
      console.log("Delete result:", result);
    } catch (error) {
      console.error("Error deleting data:", error);
    }
  };

  return (
    <div>
      <h1>Example Component</h1>
      <button onClick={handlePost}>Post Data</button>
      <button onClick={handlePut}>Put Data</button>
      <button onClick={handleDelete}>Delete Data</button>
      <pre>{JSON.stringify(data, null, 2)}</pre>
    </div>
  );
};

