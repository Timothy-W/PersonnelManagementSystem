<template>
  <div class="container">
    <div class="person-details-title">
      <h1>Personnel Details: {{ person.rank }} {{ person.lastName }}</h1>
    </div>
    <div class="container-person-details">
      <h2>First Name: {{ person.firstName }}</h2>
      <h2>Last Name: {{ person.lastName }}</h2>
      <h2>Rank: {{ person.rank }}</h2>
    </div>
  </div>
</template>

<script>
export default {
  name: "PersonDetails",
  props: {
    id: String,
  },
  data() {
    return {
      person: Object,
    };
  },
  async created() {
    const res = await fetch(`/api/person/${this.id}`);
    const data = await res.json();
    this.person = data;
  },
};
</script>

<style>
.person-details-title {
  text-align: center;
  margin-bottom: 20px;
}
</style>